using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        AccountsTableAdapter account = new AccountsTableAdapter();
        ClientsTableAdapter clients = new ClientsTableAdapter();
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login.Text))
            {
                MessageBox.Show("Введите логин.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password.Password))
            {
                MessageBox.Show("Введите пароль.");
                return;
            }

            var log = account.GetData().Where(a => a.login_account == login.Text && a.passord_account == password.Password).FirstOrDefault();

            if (log != null)
            {
                int roleID = log.role_ID;
                switch (roleID)
                {
                    case 1:
                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        Close();
                        break;
                    case 3:
                        var emp = employees.GetData().Where(em => em.account_ID == log.ID_account).FirstOrDefault();
                        if (emp != null)
                        {
                            int employeeId = emp.ID_employees;
                            EmploeeysWindow emploeeysWindow = new EmploeeysWindow(employeeId);
                            emploeeysWindow.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Сотрудника не найдено.");
                        }
                        break;

                    case 4:
                        var cli = clients.GetData().Where(c => c.account_ID == log.ID_account).FirstOrDefault();
                        if (cli != null)
                        {
                            int clientId = cli.ID_client;
                            ClientWindows clientWindow = new ClientWindows(clientId);
                            clientWindow.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Клиента не найдено.");
                        }
                        break;
                    default:
                        MessageBox.Show("Роль не определена или нет доступа.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверные учетные данные.");
            }
        }
    }
}

