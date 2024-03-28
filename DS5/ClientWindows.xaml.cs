using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using DS5.DataSet1TableAdapters;

namespace DS5
{
    public partial class ClientWindows : Window
    {
        private int ClientId { get; set; }
        private OrdersTableAdapter orders;
        public ClientWindows(int clientId)
        {
            InitializeComponent();
            this.ClientId = clientId;
            orders = new OrdersTableAdapter();
            CreateNewOrder();
            PageFrame.Content = new ProductOrederPage(GetOrderIdForClient(), this.ClientId);
        }

        private void CreateNewOrder()
        {
            try
            {
              
                var activeOrder = orders.GetClientId(ClientId)
                                        .FirstOrDefault(o => o.status_order == false);

               
                if (activeOrder == null)
                {
                    int newOrderId = orders.InsertQuery(ClientId, false);

                    MessageBox.Show("Новый заказ создан с ID: " + newOrderId);
                }
                else
                {
                    MessageBox.Show("Существующий активный заказ с ID: " + activeOrder.ID_order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании заказа: " + ex.Message);
            }
        }
        private int GetOrderIdForClient()
        {
            var order = orders.GetClientId(ClientId).ToList();
            if (order.Any())
            {
                return order.FirstOrDefault(x => !x.status_order)?.ID_order ?? 1;
            }
            return -1;
        }
        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new CheckPage(GetOrderIdForClient(), this.ClientId);
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ProductOrederPage(GetOrderIdForClient(), this.ClientId);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
