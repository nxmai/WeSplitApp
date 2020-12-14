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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window detail = new DetailWindow();

            detail.ShowDialog();
        }

        private void getId(object sender, RoutedEventArgs e)
        {
            int id = (tripdata.SelectedItem as place).id;
            MessageBox.Show($"{id}");
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //int id = (tripdata.SelectedItem as place).id;
            //MessageBox.Show($"{id}");

            //trip tmp = (sender as trip);

            //var item = (sender as ListView).SelectedItem;
            //if (item != null)
            //{
                
            //}

            var item = (sender as FrameworkElement).DataContext;
            //messagebox.show((item as recipe).name);

            //var detailscreen = new DetailScreen((item as Recipe).name);
            var x = (item as trip).id;
            MessageBox.Show($"{x}");
        }

        

        
    }
}
