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
    /// Логика взаимодействия для StocksPage.xaml
    /// </summary>
    public partial class StocksPage : Page
    {
        StocksTableAdapter adapter = new StocksTableAdapter();
        public StocksPage()
        {
            InitializeComponent();
            grid.ItemsSource = adapter.GetData();
        }
    }
}
