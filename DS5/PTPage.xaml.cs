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
    /// Логика взаимодействия для PTPage.xaml
    /// </summary>
    public partial class PTPage : Page
    {
        Products_typeTableAdapter adapter = new Products_typeTableAdapter();
        public PTPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetData();
        }
        private bool ValidateFields()
        {
            // Валидация поля названия типа продукта (TxB1)
            if (string.IsNullOrWhiteSpace(TxB1.Text))
            {
                MessageBox.Show("Введите наименование типа продукта.");
                TxB1.Focus();
                return false;
            }
            // Предположим, максимальная длина - 20 символов
            if (TxB1.Text.Length > 20)
            {
                MessageBox.Show("Наименование типа продукта слишком длинное. Максимальная длина - 20 символов.");
                TxB1.Focus();
                return false;
            }
            return true;
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                adapter.InsertQuery(TxB1.Text);
                grid.ItemsSource = adapter.GetData();
                TxB1.Clear();
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

        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = (grid.SelectedItem as DataRowView).Row[1];
            TxB1.Text = a.ToString();
        }

        private void Upadate_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(TxB1.Text, Convert.ToInt32(id));
                grid.ItemsSource = adapter.GetData();
            }
        }
    }
}
