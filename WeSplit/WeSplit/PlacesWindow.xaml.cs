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
using System.Windows.Shapes;

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for PlacesWindow.xaml
    /// </summary>
    public partial class PlacesWindow : Window
    {
        wesplitEntities1 db = new wesplitEntities1();
        public static ListView data;
        public PlacesWindow()
        {
            InitializeComponent();
            placedata.ItemsSource = db.places.ToList();
            data = placedata;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            var x = (item as place).id;
        }

        private void mainWindow(object sender, MouseButtonEventArgs e)
        {
            Window main = new MainWindow();
            main.ShowDialog();
        }
    }
}
