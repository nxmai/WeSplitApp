using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var thumbnailPath = screen.FileName;
                var savePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\fakedata\\" + Path.GetFileName(thumbnailPath);
                if (Path.GetFileName(thumbnailPath).Length > 30)
                {
                    savePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\fakedata\\" + Path.GetFileName(thumbnailPath).Substring(0, 30) + Path.GetExtension(thumbnailPath);
                }
                File.Copy(thumbnailPath, savePath, true);
                var thumbnail = new BitmapImage(new Uri(savePath, UriKind.Absolute));
                journeyThumbnail.Source = thumbnail;
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
                journeyPlace.IsEnabled = false;
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
        {
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
                Err.Text = "Hay chon ngay di";
                return;
            }

            if (_journeyEndDate == null)
            {
                Err.Text = "Hay chon ngay ve";
                return;
            }

            if (journeyThumbnail.Source == null)
            {
                Err.Text = "Hay them hinh cua dia diem";
                return;
            }

            Err.Text = "";
            var _jorneyThumbnail = "Data\\fakedata\\" + Path.GetFileName(journeyThumbnail.Source.ToString());
            if (Path.GetFileName(journeyThumbnail.Source.ToString()).Length > 30)
            {
                _jorneyThumbnail = "Data\\fakedata\\" + Path.GetFileName(journeyThumbnail.Source.ToString()).Substring(0, 30) + Path.GetExtension(journeyThumbnail.Source.ToString());
            }


            if (routeMoney.Text.Equals(""))
            {
                Err.Text = "Hay them chi phi lo trinh";
                return;
            }

            if (idTrip != -1)
            {

                var oldTrip = db.trips.Find(idTrip);
                if (_journeyBegDate != oldTrip.datetogo)
                    oldTrip.datetogo = _journeyBegDate;

                if (_journeyEndDate != oldTrip.returndate)
                    oldTrip.returndate = _journeyEndDate;

                if (_jorneyThumbnail != oldTrip.thumbnail)
                    oldTrip.thumbnail = _jorneyThumbnail;

                db.SaveChanges();

                if (routeNameEdit.Visibility == Visibility.Visible && routeNameEdit.SelectedIndex != -1)
                {
                    var id = ((route)routeNameEdit.SelectedItem).id;
                    var oldRoute = db.routes.Find(id, idTrip);
                    oldRoute.cost = int.Parse(routeMoney.Text);
                    db.SaveChanges();
                }
                else if (routeNameAddNew.Visibility == Visibility.Visible)
                {
                    if (routeNameAddNew.Text.Equals(""))
                    {
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
                    db.SaveChanges();
                }
            }
            else
            {
                if (_trip == null)
                {
                    if (journeyName.Text.Equals(""))
                    {
                        Err.Text = "Hay them ten chuyen di";
                        return;
                    }

                    if (journeyPlace.SelectedItem == null)
                    {
                        Err.Text = "Hay chon dia danh";
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
                db.SaveChanges();

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

    }
}
