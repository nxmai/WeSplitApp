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

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
   
    public partial class MainWindow : Window
    {
        wesplitEntities db = new wesplitEntities();
        public static ListView datagrid;

        public MainWindow()
        {
            InitializeComponent();

            mydatagrid.ItemsSource = db.places.ToList();
            datagrid = mydatagrid;

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window detail = new DetailWindow();

            detail.ShowDialog();
        }

        private void getId(object sender, RoutedEventArgs e)
        {
            int id = (mydatagrid.SelectedItem as place).id;
            MessageBox.Show($"{id}");
        }
    }
}
