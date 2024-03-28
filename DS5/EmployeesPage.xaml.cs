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
using static MaterialDesignThemes.Wpf.Theme;

namespace DS5
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        EmployeesTableAdapter adapter = new EmployeesTableAdapter();
        AccountsTableAdapter account = new AccountsTableAdapter();
        PassportsTableAdapter passports = new PassportsTableAdapter();
        public EmployeesPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetDataAll();
            Combobox1.ItemsSource = account.GetData();
            Combobox1.DisplayMemberPath = "login_account";
            Combobox2.ItemsSource = passports.GetData();
            Combobox2.DisplayMemberPath = "series";

        }

        private bool ValidateFields()
        {
            
            if (string.IsNullOrWhiteSpace(TxB1.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxB2.Text))
            {
                MessageBox.Show("Пожалуйста, введите фамилию.");
                return false;
            }

            if (Combobox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите аккаунт.");
                return false;
            }


            if (Combobox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите серию паспорта.");
                return false;
            }

            return true;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                object accountID = (Combobox1.SelectedItem as DataRowView).Row["ID_account"];
                object passportID = (Combobox2.SelectedItem as DataRowView).Row["ID_passport"];
                adapter.InsertQuery(TxB1.Text, TxB2.Text, TxB3.Text, Convert.ToInt32(accountID), Convert.ToInt32(passportID));
                grid.ItemsSource = adapter.GetDataAll();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row["ID_employees"];
                object accountID = (Combobox1.SelectedItem as DataRowView).Row["ID_account"];
                object passportID = (Combobox2.SelectedItem as DataRowView).Row["ID_passport"];
                adapter.UpdateQuery(TxB1.Text, TxB2.Text, TxB3.Text, Convert.ToInt32(accountID), Convert.ToInt32(passportID), Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetDataAll();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid.SelectedItem as DataRowView).Row["ID_employees"];
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

                object b = (grid.SelectedItem as DataRowView).Row[2];
                TxB2.Text = b.ToString();

                object c = (grid.SelectedItem as DataRowView).Row[3];
                TxB3.Text = c.ToString();

                foreach (var item in account.GetData())
                {
                    if ((int)(grid.SelectedItem as DataRowView).Row[4] == item.ID_account)
                    {
                        foreach (var i in Combobox1.Items)
                        {

                            if ((int)(i as DataRowView).Row[0] == item.ID_account)
                            {
                                Combobox1.SelectedItem = i;
                            }
                        }
                    }
                }
                foreach (var item in passports.GetData())
                {
                    if ((int)(grid.SelectedItem as DataRowView).Row[5] == item.ID_passport)
                    {
                        foreach (var i in Combobox2.Items)
                        {

                            if ((int)(i as DataRowView).Row[0] == item.ID_passport)
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
