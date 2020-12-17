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
    /// Interaction logic for addJourney.xaml
    /// </summary>
    public partial class AddJourney : Window
    {
       
        trip newTrip = null;
        wesplitEntities db = new wesplitEntities();
        public AddJourney()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new wesplitEntities();
            var _places = db.places.ToList<place>();
            journeyPlace.ItemsSource = _places;
        }

        private void addJourney_Click(object sender, RoutedEventArgs e)
        {
            
            db.SaveChanges();
            this.Close();
        }

        private void addRoute_Click(object sender, RoutedEventArgs e) 
        {
            if (newTrip==null)
            { 
                var _journeyName = journeyName.Text;
                var _journeyPlace = journeyPlace.SelectedItem;
                var _journeyBegDate = journeyBegDate.SelectedDate;
                var _journeyEndDate = journeyEndDate.SelectedDate;
                newTrip = new trip();
                newTrip.name = _journeyName;
                newTrip.idplace = ((place)_journeyPlace).id;
                newTrip.datetogo = _journeyBegDate;
                newTrip.returndate = _journeyEndDate;
                newTrip.isfinish = false;
                newTrip.totalrevenue = 0;
                newTrip.totalexpend = 0;
                newTrip.id = 100;
                db.trips.Add(newTrip);
            }
            var _routeName = routeName.Text;
            var _routeMoney = int.Parse(routeMoney.Text);
            var _routeDescription = routeDescription.Text;
            route newRoute = new route();
            newRoute.id = 100;
            newRoute.idtrip = newTrip.id;
            newRoute.cost = _routeMoney;
            newRoute.place = _routeName;
            db.routes.Add(newRoute);
        }

        private void addThumbail_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
