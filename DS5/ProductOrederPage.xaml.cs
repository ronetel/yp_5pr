using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DS5.DataSet1TableAdapters;

namespace DS5
{
    /// <summary>
    /// Логика взаимодействия для ProductOrederPage.xaml
    /// </summary>
    public partial class ProductOrederPage : Page
    {
        private int OrderId { get; set; }
        private int ClientId { get; set; }
        Product_in_checkTableAdapter pincheck = new Product_in_checkTableAdapter();
        ProductsTableAdapter product = new ProductsTableAdapter();
        OrdersTableAdapter order = new OrdersTableAdapter();
        public ProductOrederPage(int orderID, int clientID)
        {
            InitializeComponent();
            this.OrderId = orderID;
            this.ClientId = clientID;
            grid_product.ItemsSource = product.GetProduct();
            grid_pincheck.ItemsSource = pincheck.ok(this.OrderId);
            CheckOrderStatus(this.OrderId);
            many.Text = CalculateOrderTotal(this.OrderId).ToString();
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (grid_product.SelectedItem == null)
            {
                MessageBox.Show("Выберите продукт для добавления.");
                return;
            }

            var selectedProduct = (grid_product.SelectedItem as DataRowView).Row["ID_product"];

            if (selectedProduct != DBNull.Value)
            {
                pincheck.InsertQuery(this.OrderId, Convert.ToInt32(selectedProduct));
                grid_pincheck.ItemsSource = pincheck.ok(this.OrderId);
                many.Text = CalculateOrderTotal(this.OrderId).ToString();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (grid_pincheck.SelectedItem == null)
            {
                MessageBox.Show("Выберите продукт для удаления.");
                return;
            }
            var selectedProduct = (grid_pincheck.SelectedItem as DataRowView).Row[0];
            pincheck.DeleteQuery(Convert.ToInt32(selectedProduct));
            grid_pincheck.ItemsSource = pincheck.ok(this.OrderId);
            many.Text = CalculateOrderTotal(this.OrderId).ToString();
        }
        private bool CheckOrderStatus(int orderID)
        {
            var orders = order.GetClientId(orderID);
            if (orders != null && orders.Count > 0)
            {
                return orders[0].status_order;
            }
            return false;
        }
        private void Check()
        {
            if (!CheckOrderStatus(this.ClientId))
            {
                MessageBox.Show("Ошибка: заказ не найден или он уже обработан.");
                return;
            }

            if (!decimal.TryParse(change.Text, out decimal payment) || payment < 0)
            {
                MessageBox.Show("Внесенная сумма должна быть правильным числом.");
                change.Focus();
                return;
            }

            decimal summ = CalculateOrderTotal(this.OrderId);
            if (payment < summ)
            {
                MessageBox.Show("Внесенная сумма меньше итоговой суммы заказа.");
                change.Focus();
                return;
            }
            if (CheckOrderStatus(this.ClientId))
            {
                if (!decimal.TryParse(change.Text, out decimal payments) || payments <= 0)
                {
                    MessageBox.Show("Введите валидную сумму оплаты.");
                    change.Focus();
                    return;
                }

                decimal summa = CalculateOrderTotal(this.OrderId);
                if (payments < summa)
                {
                    MessageBox.Show("Оплаченная сумма меньше суммы заказа.");
                    return;
                }
                decimal changeAmount = payments - summa;
                order.UpdateQueryReady(DateTime.Now.ToString(), summa, this.OrderId);

                var productInCheck = pincheck.GetDataByOrderId(this.OrderId);
                var productsDetails = new StringBuilder();

                foreach (var item in productInCheck)
                {
                    var productRows = product.GetDataById(item.product_ID);
                    if (productRows.Count > 0)
                    {
                        var productRow = productRows[0];
                        productsDetails.AppendLine($"{productRow.name_product}\t-\t{productRow.price}");
                    }
                }
                string receiptText = $@"
MacDonald's
Кассовый чек №{this.OrderId}

{productsDetails}

Итого к оплате: {summa}
Внесено: {payments}
Сдача: {changeAmount}
";

                string receiptPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Чек_Номер_{this.OrderId}.txt");
                File.WriteAllText(receiptPath, receiptText, Encoding.UTF8);
                MessageBox.Show("Ваш заказ приготовлен, чек можете найти во вкладке 'Чеки'");
            }
            else
            {
                MessageBox.Show("Ошибка: заказ не найден или он уже обработан.");
            }
        }
        decimal CalculateOrderTotal(int orderId)
        {
            var productsInOrder = pincheck.GetDataByOrderId(orderId);
            decimal orderTotal = 0;
            foreach (var productInCheck in productsInOrder)
            {
                var products = product.GetDataById(productInCheck.product_ID).First();
                orderTotal += products.price;
            }
            return orderTotal;
        }
        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (CheckOrderStatus(this.ClientId))
            {
                Check();
            }
            else
            {
                MessageBox.Show("Ваш заказ готовится, чек сможете получить после приготовления");
            }


        }

    }
}
