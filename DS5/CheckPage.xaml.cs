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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DS5.DataSet1TableAdapters;

namespace DS5
{
    /// <summary>
    /// Логика взаимодействия для CheckPage.xaml
    /// </summary>
    public partial class CheckPage : Page
    {
        private int OrderId { get; set; }
        private int ClientId { get; set; }

        Product_in_checkTableAdapter pincheck = new Product_in_checkTableAdapter();
        ProductsTableAdapter product = new ProductsTableAdapter();

        OrdersTableAdapter orders = new OrdersTableAdapter();
        public CheckPage(int orderID, int clientID)
        {
            InitializeComponent();
            this.OrderId = orderID;
            this.ClientId = clientID;
            grid_check.ItemsSource = pincheck.ok(this.OrderId);
            checks.ItemsSource = orders.getall(this.ClientId);
            checks.DisplayMemberPath = "ID_order";

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
        private void checks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            var selectedOrder = checks.SelectedItem as DataRowView;

            if (selectedOrder != null)
            {
                int selectedOrderId = Convert.ToInt32(selectedOrder["ID_order"]);
                int selectedEmployeeId = Convert.ToInt32(selectedOrder[0]);
                grid_check.ItemsSource = pincheck.ok(selectedOrderId);

                var employeeInfo = orders.getIDemp(selectedEmployeeId);
                if (employeeInfo.Count > 0)
                {
                    var employeeRow = employeeInfo[0]; 
                    emp.Text = $"{employeeRow["name_emp"]} {employeeRow["surname_emp"]} {employeeRow["midlname_emp"]}";
                }

                date.Text = Convert.ToDateTime(selectedOrder["date_check"]).ToString("dd/MM/yyyy");
                summ.Text = $"{CalculateOrderTotal(selectedOrderId):C2}";
            }
        }
    }
}
