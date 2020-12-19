using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace WeSplit
{
    /// <summary>
    /// Interaction logic for EditJourney.xaml
    /// </summary>
    public partial class EditJourney : Window
    {
        public delegate void DeathHandler();
        public event DeathHandler Dying;

        int idTrip = -1;
        public BindingList<route> _routes;
        trip _trip = null;
        String newPath = "";
        public String oldPath = "";
        public EditJourney(int id)
        {
            InitializeComponent();
            idTrip = id;

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dying?.Invoke();
        }
        public EditJourney()
        {
            InitializeComponent();
        }

        private void addThumbail_Click(object sender, RoutedEventArgs e)
        {
            if (journeyThumbnail.Source != null)
                oldPath = journeyThumbnail.Source.ToString().Substring(8);
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var thumbnailPath = screen.FileName;
                newPath = "Data/fakedata/" + Guid.NewGuid() + Path.GetExtension(thumbnailPath);
                var savePath = AppDomain.CurrentDomain.BaseDirectory + newPath;
                File.Copy(thumbnailPath, savePath, true);
                var thumbnail = new BitmapImage(new Uri(savePath, UriKind.Absolute));

                journeyThumbnail.Source = thumbnail;
            }
            if (idTrip != -1)
            {
                var db = new wesplitEntities();
                var oldTrip = db.trips.Find(idTrip);
                if (!newPath.Equals(oldTrip.thumbnail))
                    oldTrip.thumbnail = newPath;

                db.SaveChanges();
                Err.Foreground = Brushes.Green;
                Err.Text = "Da cap nhat thong tin chuyen di";
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new wesplitEntities();
            if (idTrip == -1)
            {
                journeyPlace.ItemsSource = new BindingList<place>(db.places.ToList());
                addRouteAddNew_Click(sender, e);
                addRouteEdit.IsEnabled = false;
            }
            else
            {
                journeyName.IsEnabled = false;
                journeyName.Foreground = Brushes.Gray;
                journeyPlace.IsEnabled = false;
                journeyPlace.Foreground = Brushes.Gray;
                journeyBegDate.IsEnabled = false;
                journeyEndDate.IsEnabled = false;
                _trip = db.trips.Find(idTrip);
                journeyPlace.ItemsSource = new BindingList<place>(db.places.Where(x => x.id == _trip.idplace).ToList());
                journeyPlace.SelectedIndex = 0;
                journeyName.Text = _trip.name;
                journeyBegDate.SelectedDate = _trip.datetogo;
                journeyEndDate.SelectedDate = _trip.returndate;
                _routes = new BindingList<route>(_trip.routes.ToList());
                routeNameEdit.ItemsSource = _routes;
                routeList.ItemsSource = _routes;
                journeyThumbnail.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + _trip.thumbnail, UriKind.Absolute));
                journeyEndDate.BlackoutDates.Add(new CalendarDateRange(new DateTime(1, 1, 1), (DateTime)journeyBegDate.SelectedDate));
            }
        }

        private void routeName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (routeNameEdit.SelectedItem != null)
                routeMoney.Text = ((route)routeNameEdit.SelectedItem).cost.ToString();
        }

        private void finishEditJourney_Click(object sender, RoutedEventArgs e)
        {/*
            if (idTrip != -1)
            {
                DetailWindow detailScreen = new DetailWindow(idTrip);
                this.Close();
                detailScreen.Show();
            }
            else
            {
                this.Close();
            }*/
            this.Close();
        }

        private void addRouteEdit_Click(object sender, RoutedEventArgs e)
        {
            routeNameEdit.Visibility = Visibility.Visible;
            routeNameAddNew.Visibility = Visibility.Collapsed;
            addRouteAddNew.Visibility = Visibility.Visible;
            addRouteEdit.Visibility = Visibility.Collapsed;
            if (routeNameEdit.SelectedItem != null)
                routeMoney.Text = ((route)routeNameEdit.SelectedItem).cost.ToString();
            routeNameAddNew.Text = "";
        }

        private void addRouteAddNew_Click(object sender, RoutedEventArgs e)
        {
            routeNameEdit.Visibility = Visibility.Collapsed;
            routeNameAddNew.Visibility = Visibility.Visible;
            addRouteAddNew.Visibility = Visibility.Collapsed;
            addRouteEdit.Visibility = Visibility.Visible;
            routeMoney.Text = "";
        }

        private void saveRoute_Click(object sender, RoutedEventArgs e)
        {
            var db = new wesplitEntities();
            var _journeyBegDate = journeyBegDate.SelectedDate;
            var _journeyEndDate = journeyEndDate.SelectedDate;

            if (_journeyBegDate == null)
            {
                Err.Foreground = Brushes.Red;
                Err.Text = "Hay chon ngay di";
                return;
            }

            if (_journeyEndDate == null)
            {
                Err.Foreground = Brushes.Red;
                Err.Text = "Hay chon ngay ve";
                return;
            }

            if (journeyThumbnail.Source == null)
            {
                Err.Foreground = Brushes.Red;
                Err.Text = "Hay them hinh cua dia diem";
                return;
            }

            Err.Text = "";

            var _jorneyThumbnail = newPath;

            if (routeMoney.Text.Equals(""))
            {
                Err.Foreground = Brushes.Red;
                Err.Text = "Hay them chi phi lo trinh";
                return;
            }

            if (idTrip != -1)
            {

                var oldTrip = db.trips.Find(idTrip);
                if (!_journeyBegDate.Equals(oldTrip.datetogo))
                    oldTrip.datetogo = _journeyBegDate;

                if (!_journeyEndDate.Equals(oldTrip.returndate))
                    oldTrip.returndate = _journeyEndDate;

                db.SaveChanges();
                Err.Foreground = Brushes.Green;
                Err.Text = "Da cap nhat thong tin chuyen di";


                if (routeNameEdit.Visibility == Visibility.Visible && routeNameEdit.SelectedIndex != -1)
                {
                    var id = ((route)routeNameEdit.SelectedItem).id;
                    var oldRoute = db.routes.Find(id);
                    oldRoute.cost = int.Parse(routeMoney.Text);
                    db.SaveChanges();
                    Err.Foreground = Brushes.Green;
                    Err.Text = "Da cap nhat thong tin lo trinh";
                }
                else if (routeNameAddNew.Visibility == Visibility.Visible)
                {
                    if (routeNameAddNew.Text.Equals(""))
                    {
                        Err.Foreground = Brushes.Red;
                        Err.Text = "Hay them ten lo trinh";
                        return;
                    }

                    var maxId = db.routes.Max(x => x.id);
                    route newRoute = new route();
                    newRoute.id = maxId + 1;
                    newRoute.idtrip = idTrip;
                    newRoute.cost = int.Parse(routeMoney.Text);
                    newRoute.place = routeNameAddNew.Text;
                    db.routes.Add(newRoute);
                    Err.Foreground = Brushes.Green;
                    Err.Text = "Da them moi lo trinh";
                    db.SaveChanges();
                }
            }
            else
            {
                if (_trip == null)
                {
                    if (journeyName.Text.Equals(""))
                    {
                        Err.Foreground = Brushes.Red;
                        Err.Text = "Hay them ten chuyen di";
                        return;
                    }

                    if (journeyPlace.SelectedItem == null)
                    {
                        Err.Foreground = Brushes.Red;
                        Err.Text = "Hay chon dia danh";
                        return;
                    }

                    if (routeNameAddNew.Text.Equals(""))
                    {
                        Err.Foreground = Brushes.Red;
                        Err.Text = "Hay them ten lo trinh";
                        return;
                    }

                    journeyName.IsEnabled = false;
                    journeyPlace.IsEnabled = false;
                    addThumbail.IsEnabled = false;
                    journeyBegDate.IsEnabled = false;
                    journeyEndDate.IsEnabled = false;

                    var _journeyName = journeyName.Text;
                    var _journeyPlace = journeyPlace.SelectedItem;
                    _trip = new trip();
                    _trip.name = _journeyName;
                    _trip.idplace = ((place)_journeyPlace).id;
                    _trip.datetogo = _journeyBegDate;
                    _trip.returndate = _journeyEndDate;
                    _trip.thumbnail = _jorneyThumbnail;
                    _trip.isfinish = false;
                    _trip.totalrevenue = 0;
                    _trip.totalexpend = 0;
                    _trip.id = db.trips.Max(x => x.id) + 1;
                    db.trips.Add(_trip);
                    Err.Foreground = Brushes.Green;
                    Err.Text = "Da them moi chuyen di";
                    db.SaveChanges();
                }
                var _routeName = routeNameAddNew.Text;
                var _routeMoney = int.Parse(routeMoney.Text);
                //var _routeDescription = routeDescription.Text;
                route newRoute = new route();
                newRoute.id = db.routes.Max(x => x.id) + 1;
                newRoute.idtrip = _trip.id;
                newRoute.cost = _routeMoney;
                newRoute.place = _routeName;
                db.routes.Add(newRoute);
                Err.Foreground = Brushes.Green;
                Err.Text = "Da them moi lo trinh";
                db.SaveChanges();
                routeNameAddNew.Text = "";
                routeMoney.Text = "";

            }
            _routes = new BindingList<route>(db.routes.Where(x => x.idtrip == _trip.id || x.idtrip == idTrip).ToList());
            routeList.ItemsSource = _routes;
            var tmp = routeNameEdit.SelectedIndex;
            routeNameEdit.ItemsSource = _routes;
            routeNameEdit.SelectedIndex = tmp;
            //db.SaveChanges();
        }

        private void journeyBegDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            journeyEndDate.BlackoutDates.Clear();
            journeyEndDate.SelectedDate = null;
            journeyEndDate.BlackoutDates.Add(new CalendarDateRange(new DateTime(1, 1, 1), (DateTime)journeyBegDate.SelectedDate));
        }

        private void routeMoney_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var money = int.Parse(routeMoney.Text);
                Err.Text = "";
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Err.Text = "Tien la so nguyen";
                routeMoney.Text = "";
                //routeMoney.Focus();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            /*Debug.WriteLine(oldPath);
            Debug.WriteLine(journeyThumbnail.Source.ToString());*/
        }
    }
}
