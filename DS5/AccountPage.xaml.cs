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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        AccountsTableAdapter adapter = new AccountsTableAdapter();
        RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();
        public AccountPage()
        {
            InitializeComponent();
            grid_acc.ItemsSource = adapter.GetData();
            id_role.ItemsSource = rolesTableAdapter.GetData();
            id_role.DisplayMemberPath = "name_role";
        }
        private bool ValidateFields()
        {
            // Проверка на пустой логин
            if (string.IsNullOrWhiteSpace(login.Text))
            {
                MessageBox.Show("Поле 'Логин' не может быть пустым.");
                login.Focus();
                return false;
            }

            // Проверка на пустой пароль
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Поле 'Пароль' не может быть пустым.");
                password.Focus();
                return false;
            }

            // Проверка на выбранную роль
            if (id_role.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать роль из списка.");
                id_role.Focus();
                return false;
            }

            // Здесь можно добавить условия сложности для логина и пароля, например, минимальную длину

            return true;
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                object title = (id_role.SelectedItem as DataRowView).Row[0];
                adapter.InsertQuery(login.Text, password.Text, Convert.ToInt32(title));
                grid_acc.ItemsSource = adapter.GetData();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (grid_acc.SelectedItem != null && ValidateFields())
            {
                object id = (grid_acc.SelectedItem as DataRowView).Row[0];
                object name_role = (id_role.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(login.Text, password.Text, Convert.ToInt32(name_role), Convert.ToInt32(id));
                grid_acc.ItemsSource = adapter.GetData();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid_acc.SelectedItem as DataRowView).Row[0];
                adapter.DeleteQuery(Convert.ToInt32(id));
                grid_acc.ItemsSource = adapter.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid_acc.SelectedItem != null)
            {
                object log = (grid_acc.SelectedItem as DataRowView).Row[1];
                login.Text = log.ToString();

                object pas = (grid_acc.SelectedItem as DataRowView).Row[2];
                password.Text = pas.ToString();

                foreach (var item in rolesTableAdapter.GetData())
                {
                    if ((int)(grid_acc.SelectedItem as DataRowView).Row[3] == item.ID_role)
                    {
                        foreach (var i in id_role.Items)
                        {

                            if ((int)(i as DataRowView).Row[0] == item.ID_role)
                            {
                                id_role.SelectedItem = i;
                            }
                        }
                    }
                }
            }

        }
    }
}
