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
    public partial class AdminWindow : Window
    {
        DataSet1 a = new DataSet1();

        public AdminWindow()
        {
            InitializeComponent();
            var tableDisplay = new List<string> { "Accounts", "Roles", "Employees", "Passports", "Clients", "Ingrediends",
                                                 "Products", "Products_type", "Providers", "Resept", "Stocks"};

            var filterTables = a.Tables.Cast<DataTable>().Where(t => tableDisplay.Contains(t.TableName)).ToList();
            ComboTable.ItemsSource = filterTables;
            ComboTable.DisplayMemberPath = "TableName";
        }
    
    private void ComboTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ComboTable.SelectedItem;

            if (selectedItem != null)
            {
                string tableName = (string)selectedItem.GetType().GetProperty("TableName").GetValue(selectedItem, null);

                if (!string.IsNullOrEmpty(tableName))
                {
                    switch (tableName)
                    {
                        case "Accounts":
                            PageFrame.Content = new AccountPage();
                            break;
                        case "Roles":
                            PageFrame.Content = new RolePage();
                            break;
                        case "Employees":
                            PageFrame.Content = new EmployeesPage();
                            break;
                        case "Passports":
                            PageFrame.Content = new PassportPage();
                            break;
                        case "Clients":
                            PageFrame.Content = new ClientPage();
                            break;
                        case "Products":
                            PageFrame.Content = new ProductPage();
                            break;
                        case "Products_type":
                            PageFrame.Content = new PTPage();
                            break;
                        case "Providers":
                            PageFrame.Content = new ProvidersPage();
                            break;
                        case "Stocks":
                            PageFrame.Content = new StocksPage();
                            break;
                        case "Resept":
                            PageFrame.Content = new ReseptPage();
                            break;
                        case "Ingrediends":
                            PageFrame.Content = new IngPage();
                            break;
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void BuckUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QueriesTableAdapter querry = new QueriesTableAdapter();
                querry.ok();
                MessageBox.Show("Бэкап успешно создан");
            }
            catch (Exception ex)
            {
              
                MessageBox.Show($"Произошла ошибка при создании бэкапа: {ex.Message}");
            }
        }
    }
}