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
        public static ListView data;

        public MainWindow()
        {
            InitializeComponent();

            tripdata.ItemsSource = db.trips.ToList();
            data = tripdata;
        }
        
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            var x = (item as trip).id;

            Window detail = new DetailWindow(x);
            detail.ShowDialog();
        }

        private void placeWindow(object sender, MouseButtonEventArgs e)
        {
            Window place = new PlacesWindow();
            place.ShowDialog();
        }
    }
}
