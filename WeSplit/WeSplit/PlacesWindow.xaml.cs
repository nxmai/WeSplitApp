using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for PlacesWindow.xaml
    /// </summary>
    public partial class PlacesWindow : Window
    {
        public delegate void DeathHandler();
        public event DeathHandler Dying;
        wesplitEntities db = new wesplitEntities();
        public static ListView data;
        private System.Timers.Timer _timer;
        public PlacesWindow()
        {
            InitializeComponent();
            placedata.ItemsSource = db.places.ToList();
            data = placedata;
            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += _timer_Elapsed;

        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => { Notif.Text = ""; });
        }

    private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            var x = (item as place).id;
        }

        private void mainWindow(object sender, MouseButtonEventArgs e)
        {
            /* Window main = new MainWindow();
             main.ShowDialog();*/
            this.Close();
        }

        private void addPlace_Click(object sender, RoutedEventArgs e)
        {
            if (namePlace.Text.Equals("") || addrPlace.Text.Equals("") || descrPlace.Text.Equals(""))
            {
                _timer.Start();
                Notif.Foreground = Brushes.Red;
                Notif.Text = "Nhap day du cac thong tin di. Nhap thieu thong tin sao them";
                return;
            }
            var db = new wesplitEntities();
            var _place = new place();
            _place.id = db.places.Max(x => x.id) + 1;
            _place.name = namePlace.Text;
            _place.address = addrPlace.Text;
            _place.discription = descrPlace.Text;
            db.places.Add(_place);
            db.SaveChanges();
            placedata.ItemsSource = db.places.ToList();
            data = placedata;
            namePlace.Text = "";
            addrPlace.Text = "";
            descrPlace.Text = "";
            Notif.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dying?.Invoke();
        }
    }
}
