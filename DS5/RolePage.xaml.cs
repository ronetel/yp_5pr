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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        RolesTableAdapter adapter = new RolesTableAdapter();
        public RolePage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetData();
        }
        
            private bool ValidateFields()
            {
                if (string.IsNullOrWhiteSpace(name_role.Text))
                {
                    MessageBox.Show("Поле 'Имя должности' не может быть пустым.");
                    name_role.Focus();
                    return false;
                }

            if (name_role.Text.Length > 30)
            {
                MessageBox.Show("Название должности слишком длинное. Должно быть не более 30 символов.");
                name_role.Focus();
                return false;
            }

            return true; 
            }
        
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields()) 
            {
                adapter.InsertQuery(name_role.Text);
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
                MessageBox.Show("Эта роль связанна, нельзя удалить");
            }
        }

        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid.SelectedItem != null)
            {
                object log = (grid.SelectedItem as DataRowView).Row[1];
                name_role.Text = log.ToString();
            }
        }
    }
}
