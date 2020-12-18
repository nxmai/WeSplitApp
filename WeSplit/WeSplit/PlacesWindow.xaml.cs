using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for PlacesWindow.xaml
    /// </summary>
    public partial class PlacesWindow : Window
    {
        wesplitEntities db = new wesplitEntities();
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
