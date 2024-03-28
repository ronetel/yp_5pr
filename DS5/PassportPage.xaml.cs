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
    /// Логика взаимодействия для PassportPage.xaml
    /// </summary>
    public partial class PassportPage : Page
    {
        PassportsTableAdapter adapter = new PassportsTableAdapter();
        public PassportPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetData();
        }
        private bool ValidateFields()
        {
            if (!int.TryParse(TxB1.Text, out int series))
            {
                MessageBox.Show("Серия паспорта должна быть числом.");
                TxB1.Focus();
                return false;
            }

            if (!int.TryParse(TxB2.Text, out int number))
            {
                MessageBox.Show("Номер паспорта должен быть числом.");
                TxB2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxB3.Text))
            {
                MessageBox.Show("Поле 'Выдан' не может быть пустым.");
                TxB3.Focus();
                return false;
            }

            if (!int.TryParse(TxB4.Text, out int departmentCode))
            {
                MessageBox.Show("Код подразделения должен быть числовым и обычно содержит 6 цифр.");
                TxB4.Focus();
                return false;
            }

            if (!DateTime.TryParse(TxB5.Text, out DateTime dateIssued))
            {
                MessageBox.Show("Введите корректную дату выдачи в формате ДД.ММ.ГГГГ.");
                TxB5.Focus();
                return false;
            }


            return true;
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                adapter.InsertQuery(Convert.ToInt32(TxB1.Text), Convert.ToInt32(TxB2.Text), TxB3.Text, Convert.ToInt32(TxB4.Text), TxB5.Text);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(Convert.ToInt32(TxB1.Text), Convert.ToInt32(TxB2.Text), TxB3.Text, Convert.ToInt32(TxB4.Text), TxB5.Text, Convert.ToInt32(id));
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                adapter.DeleteQuery(Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid.SelectedItem != null)
            {
                object a = (grid.SelectedItem as DataRowView).Row[1];
                TxB1.Text = a.ToString();

                object b = (grid.SelectedItem as DataRowView).Row[2];
                TxB2.Text = b.ToString();

                object c = (grid.SelectedItem as DataRowView).Row[3];
                TxB3.Text = c.ToString();

                object d = (grid.SelectedItem as DataRowView).Row[4];
                TxB4.Text = d.ToString();

                object f = (grid.SelectedItem as DataRowView).Row[5];
                TxB5.Text = f.ToString();
            }
        }
    }
}
