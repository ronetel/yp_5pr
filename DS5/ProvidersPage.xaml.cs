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
    /// Логика взаимодействия для ProvidersPage.xaml
    /// </summary>
    public partial class ProvidersPage : Page
    {
        ProvidersTableAdapter adapter = new ProvidersTableAdapter();
        public ProvidersPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetData();
        }
        private bool ValidateFields()
        {
            // Валидация поля "Имя поставщика" (TxB1)
            if (string.IsNullOrWhiteSpace(TxB1.Text))
            {
                MessageBox.Show("Введите имя поставщика.");
                TxB1.Focus();
                return false;
            }

            // Валидация поля "Адрес" (TxB2)
            if (string.IsNullOrWhiteSpace(TxB2.Text))
            {
                MessageBox.Show("Введите адрес поставщика.");
                TxB2.Focus();
                return false;
            }

            // Дополнительные проверки по необходимости

            return true; // Все проверки прошли успешно
        }
        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = (grid.SelectedItem as DataRowView).Row[1];
            TxB1.Text = a.ToString();

            object c = (grid.SelectedItem as DataRowView).Row[2];
            TxB2.Text = c.ToString();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                adapter.InsertQuery(TxB1.Text, TxB2.Text);
                grid.ItemsSource = adapter.GetData();
                
            }
        }

        private void Upadate_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(TxB1.Text,TxB2.Text, Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetData();
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
                MessageBox.Show("Ошибка при попытке удаления.");
            }
        }
    }
}
