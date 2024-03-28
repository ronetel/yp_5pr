using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace DS5
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        ProductsTableAdapter adapter = new ProductsTableAdapter();
        Products_typeTableAdapter products = new Products_typeTableAdapter();
        public ProductPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetProduct();
            Combobox1.ItemsSource = products.GetData();
            Combobox1.DisplayMemberPath = "product_type";
        }
        private bool ValidateFields()
        {
            decimal price;
            if (string.IsNullOrWhiteSpace(TxB1.Text))
            {
                MessageBox.Show("Введите название продукта.");
                TxB1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxB2.Text) || !decimal.TryParse(TxB2.Text, out price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену (положительное число).");
                TxB2.Focus();
                return false;
            }
            if (Combobox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип продукта.");
                Combobox1.Focus();
                return false;
            }

            return true;
        }
        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid.SelectedItem != null && grid.SelectedItem != null)
            {
                object a = (grid.SelectedItem as DataRowView).Row[1];
                TxB1.Text = a.ToString();

                object b = (grid.SelectedItem as DataRowView).Row[2];
                TxB2.Text = b.ToString();

                foreach (var item in products.GetData())
                {
                    if ((int)(grid.SelectedItem as DataRowView).Row[3] == item.ID_product_type)
                    {
                        foreach (var i in Combobox1.Items)
                        {

                            if ((int)(i as DataRowView).Row[0] == item.ID_product_type)
                            {
                                Combobox1.SelectedItem = i;
                            }
                        }
                    }
                }
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                object accountID = (Combobox1.SelectedItem as DataRowView).Row[0];
                adapter.InsertQuery(TxB1.Text, Convert.ToDecimal(TxB2.Text), Convert.ToInt32(accountID));
                grid.ItemsSource = adapter.GetProduct();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                object accountID = (Combobox1.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(TxB1.Text, Convert.ToDecimal(TxB2.Text), Convert.ToInt32(accountID), Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetProduct();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                adapter.DeleteQuery(Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetProduct();
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке удаления сотрудника.");
            }
        }
    }
}
