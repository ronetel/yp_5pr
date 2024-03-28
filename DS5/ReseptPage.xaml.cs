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
using static MaterialDesignThemes.Wpf.Theme;

namespace DS5
{
    /// <summary>
    /// Логика взаимодействия для ReseptPage.xaml
    /// </summary>
    public partial class ReseptPage : Page
    {
        ReseptTableAdapter adapter = new ReseptTableAdapter();
        IngrediendsTableAdapter ingrediends = new IngrediendsTableAdapter();
        ProductsTableAdapter products = new ProductsTableAdapter();
        public ReseptPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetDataAll();
            Combobox1.ItemsSource = products.GetData();
            Combobox1.DisplayMemberPath = "name_product";
            Combobox2.ItemsSource = ingrediends.GetData();
            Combobox2.DisplayMemberPath = "name_ing";

        }
        private bool ValidateFields()
        {
            // Проверяем, что для продукта выбран элемент из ComboBox
            if (Combobox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите продукт из списка.");
                Combobox1.Focus();
                return false;
            }

            // Проверяем, что для ингредиента выбран элемент из ComboBox
            if (Combobox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите ингредиент из списка.");
                Combobox2.Focus();
                return false;
            }

            return true; // Если обе проверки пройдены успешно
        }
        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in products.GetData())
            {
                if ((int)(grid.SelectedItem as DataRowView).Row[1] == item.ID_product)
                {
                    foreach (var i in Combobox1.Items)
                    {

                        if ((int)(i as DataRowView).Row[0] == item.ID_product)
                        {
                            Combobox1.SelectedItem = i;
                        }
                    }
                }
            }
            foreach (var item in ingrediends.GetData())
            {
                if ((int)(grid.SelectedItem as DataRowView).Row[2] == item.ID_ingrediend)
                {
                    foreach (var i in Combobox2.Items)
                    {

                        if ((int)(i as DataRowView).Row[0] == item.ID_ingrediend)
                        {
                            Combobox2.SelectedItem = i;
                        }
                    }
                }
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                object accountID = (Combobox1.SelectedItem as DataRowView).Row[0];
                object passportID = (Combobox2.SelectedItem as DataRowView).Row[0];
                adapter.InsertQuery( Convert.ToInt32(accountID), Convert.ToInt32(passportID));
                grid.ItemsSource = adapter.GetDataAll();
            }
        }

        private void Upadate_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null && ValidateFields())
            {
                object id = (grid.SelectedItem as DataRowView).Row[0];
                object accountID = (Combobox1.SelectedItem as DataRowView).Row[0];
                object passportID = (Combobox2.SelectedItem as DataRowView).Row[0];
                adapter.UpdateQuery(Convert.ToInt32(accountID), Convert.ToInt32(passportID), Convert.ToInt32(id));
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
                MessageBox.Show("Ошибка при попытке удаления.");
            }
        }
    }
}
