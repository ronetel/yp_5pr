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
namespace DS5
{
    /// <summary>
    /// Логика взаимодействия для IngPage.xaml
    /// </summary>
    public partial class IngPage : Page
    {
        IngrediendsTableAdapter adapter = new IngrediendsTableAdapter();
        StocksTableAdapter stocks = new StocksTableAdapter();
        ProvidersTableAdapter providers = new ProvidersTableAdapter();
        public IngPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetDataAll();
            Combobox1.ItemsSource = providers.GetData();
            Combobox1.DisplayMemberPath = "name_provider";
            Combobox2.ItemsSource = stocks.GetData();
            Combobox2.DisplayMemberPath = "name_stock";
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(TxB1.Text))
            {
                MessageBox.Show("Введите название ингредиента.");
                TxB1.Focus();
                return false;
            }

            if (Combobox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставщика из списка.");
                Combobox1.Focus();
                return false;
            }

            if (Combobox2.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад из списка.");
                Combobox2.Focus();
                return false;
            }

            int quantity;
            bool isNumeric = int.TryParse(TxB2.Text, out quantity);
            if (string.IsNullOrWhiteSpace(TxB2.Text) || !isNumeric || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество (целое положительное число).");
                TxB2.Focus();
                return false;
            }

            return true;
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                object accountID = (Combobox1.SelectedItem as DataRowView).Row[0];
                object passportID = (Combobox2.SelectedItem as DataRowView).Row[0];
                adapter.InsertQuery(TxB1.Text, Convert.ToInt32(accountID), Convert.ToInt32(passportID), Convert.ToInt32(TxB2.Text));
                grid.ItemsSource = adapter.GetDataAll();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                object accountID = (Combobox1.SelectedItem as DataRowView).Row[0];
                object passportID = (Combobox2.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(TxB1.Text, Convert.ToInt32(accountID), Convert.ToInt32(passportID), Convert.ToInt32(TxB2.Text), Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetDataAll();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                adapter.DeleteQuery(Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetDataAll();
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке удаления сотрудника.");
            }
        }

        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid.SelectedItem != null && grid.SelectedItem != null)
            {
                object a = (grid.SelectedItem as DataRowView).Row[1];
                TxB1.Text = a.ToString();

                object b = (grid.SelectedItem as DataRowView).Row[4];
                TxB2.Text = b.ToString();


                foreach (var item in providers.GetData())
                {
                    if ((int)(grid.SelectedItem as DataRowView).Row[2] == item.ID_provider)
                    {
                        foreach (var i in Combobox1.Items)
                        {

                            if ((int)(i as DataRowView).Row[0] == item.ID_provider)
                            {
                                Combobox1.SelectedItem = i;
                            }
                        }
                    }
                }
                foreach (var item in stocks.GetData())
                {
                    if ((int)(grid.SelectedItem as DataRowView).Row[3] == item.ID_stocks)
                    {
                        foreach (var i in Combobox2.Items)
                        {

                            if ((int)(i as DataRowView).Row[0] == item.ID_stocks)
                            {
                                Combobox2.SelectedItem = i;
                            }
                        }
                    }
                }
            }
        }
    }
}
