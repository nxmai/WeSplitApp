using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    /// 
    public class restMoney
    {
        public string name { get; set; }

        public float rest { get; set; }

    }

    public class finalSummary
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalCollectedMoney { get; set; }
        public int totalCostMoney { get; set; }
        public string thumbnail { get; set; }
        public Nullable<System.DateTime> datetogo { get; set; }
        public Nullable<System.DateTime> returndate { get; set; }

        public bool status { get; set; }
    }
    public partial class DetailWindow : Window
    {
        wesplitEntities db = new wesplitEntities();
        finalSummary selectedTrip = new finalSummary();
        List<member> listMember = new List<member>();
        List<route> listRoute = new List<route>();
        List<restMoney> listRestMoney = new List<restMoney>();
        List<image> listImage = new List<image>();

        public delegate void DeathHandler();
        public event DeathHandler Dying;

        public String oldpath = "";
        int ID;
        public DetailWindow(int id)
        {
            InitializeComponent();
            ID = id;
            CreateData(ID);
            BidingData();
            customizeWindow();
        }


        void customizePieChart()
        {
            customizeTienThuChart();
            customizeTienChiChart();

        }

        void customizeTienThuChart()
        {
            //Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection piechartData = new SeriesCollection();

            foreach (member tempMember in listMember)
            {
                piechartData.Add(new PieSeries
                {
                    Title = tempMember.name,
                    Values = new ChartValues<float> { (int)tempMember.collectedmoney },

                });

            }

            tienThuPie.Series = piechartData;
        }
        void customizeTienChiChart()
        {
            SeriesCollection piechartData = new SeriesCollection();

            foreach (route tempLichTrinh in listRoute)
            {
                piechartData.Add(new PieSeries
                {
                    Title = tempLichTrinh.place,
                    Values = new ChartValues<float> { float.Parse(tempLichTrinh.cost.ToString()) },
                    // DataLabels = true
                    // LabelPoint = labelPoint
                });

            }

            tienChiPie.Series = piechartData;
        }

        private void tienThuPie_DataClick(object sender, ChartPoint chartPoint)
        {

            var chart = chartPoint.ChartView as PieChart;
            foreach (PieSeries series in chart.Series)
            {
                series.PushOut = 0;
            }
            var selectedSeries = chartPoint.SeriesView as PieSeries;
            selectedSeries.PushOut = 15;

        }


        void loadDataFromDB(int id)
        {
            var db = new wesplitEntities();
            listRoute = db.routes.Where(x => x.idtrip == id).ToList();
            listMember = db.members.Where(x => x.idtrip == id).ToList();


            //MessageBox.Show(db.members.Where(x => x.idtrip == id).Count().ToString());
        }

        void createDataSelectedTrip(int id)
        {
            var db = new wesplitEntities();
            selectedTrip.id = id;

            var temp = db.trips.Where(x => x.id == id).First();

            selectedTrip.name = temp.name;
            selectedTrip.returndate = temp.returndate;
            selectedTrip.datetogo = temp.datetogo;
            selectedTrip.thumbnail = temp.thumbnail;
            selectedTrip.status = (bool)temp.isfinish;

            int totalCost = 0;
            foreach (var tempPlace in listRoute)
            {
                if (tempPlace.cost != null)
                {
                    totalCost += (int)tempPlace.cost;
                }
            }
            selectedTrip.totalCostMoney = totalCost;

            int totalCollected = 0;
            foreach (var tempMember in listMember)
            {
                if (tempMember.collectedmoney != null)
                {
                    totalCollected += (int)tempMember.collectedmoney;
                }
            }
            selectedTrip.totalCollectedMoney = totalCollected;
        }

        void CreateListRestMoney()
        {
            float totalCost = selectedTrip.totalCostMoney;
            float amountMember = listMember.Count();
            float costForEachMember = totalCost / amountMember;
            foreach (var tempMember in listMember)
            {
                restMoney temp = new restMoney();
                temp.name = tempMember.name;
                temp.rest = costForEachMember - (int)tempMember.collectedmoney;
                listRestMoney.Add(temp);
            }

        }

        void createListImage(int id)
        {
            var db = new wesplitEntities();
            listImage = db.images.Where(x => x.idtrip == id).ToList();
            // MessageBox.Show(listImage.Count().ToString());
        }

        void CreateData(int id)
        {
            loadDataFromDB(id);
            createDataSelectedTrip(id);
            CreateListRestMoney();
            createListImage(id);
        }

        void BidingData()
        {
            lvDiaDiem.ItemsSource = listRoute;

            lvTienConLai.ItemsSource = listRestMoney;

            lvTienThu.ItemsSource = listMember;

            journeyBegDate.DataContext = selectedTrip;
            journeyEndDate.DataContext = selectedTrip;
        }

        void customizeWindow()
        {
            journeyName.Text = selectedTrip.name;
            collectedTotalTxt.Text = selectedTrip.totalCollectedMoney.ToString();
            costTotalTxt.Text = selectedTrip.totalCostMoney.ToString();
            //dateGoTXT.Text = selectedTrip.datetogo.ToString();
            // dateReturnTXT.Text = selectedTrip.returndate.ToString();
            try
            {
                var uri = new Uri(getFolder() + $"{selectedTrip.thumbnail}", UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                thumbnailImage.ImageSource = bitmap;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
            createCarousel();

            customizePieChart();

            if (selectedTrip.status == true)
            {
                borderButtonEnd.Visibility = Visibility.Collapsed;
            }
            else
            {
                endTXT.Visibility = Visibility.Collapsed;
            }
        }

        string getFolder()
        {
            string folder = "";
            folder = AppDomain.CurrentDomain.BaseDirectory;
            folder += $"/";
            return folder;
        }

        void createCarousel()
        {
            foreach (var tempImage in listImage)
            {

                var border = new Border();
                border.CornerRadius = new CornerRadius(15);

                var temp = new ImageBrush();
                var uri = new Uri(getFolder() + $"{tempImage.path}", UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                temp.ImageSource = bitmap;


                border.Background = temp;
                border.Width = 100;
                border.Height = 90;

                border.Margin = new Thickness(0, 0, 3, 0);

                carousel.Children.Add(border);
            }

        }

        private void EndClick(object sender, RoutedEventArgs e)
        {
            var select = db.trips.Where(x => x.id == selectedTrip.id).SingleOrDefault();
            select.isfinish = true;
            db.SaveChanges();
            borderButtonEnd.Visibility = Visibility.Collapsed;
            endTXT.Visibility = Visibility.Visible;
        }

        private void addImageClick(object sender, RoutedEventArgs e)
        {
            List<String> FilePath = new List<string>();
            var screen = new OpenFileDialog();
            screen.Multiselect = true;
            if (screen.ShowDialog() == true)
            {
                var thumbnailPaths = screen.FileNames;
                foreach (var thumbnailPath in thumbnailPaths)
                {
                    var savePath = "Data/fakedata/" + Guid.NewGuid() + Path.GetExtension(thumbnailPath);
                    FilePath.Add(savePath);
                    File.Copy(thumbnailPath, AppDomain.CurrentDomain.BaseDirectory + savePath, true);
                    var thumbnail = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + savePath, UriKind.Absolute));
                    var border = new Border();
                    border.CornerRadius = new CornerRadius(15);

                    var temp = new ImageBrush();

                    temp.ImageSource = thumbnail;


                    border.Background = temp;
                    border.Width = 100;
                    border.Height = 90;

                    border.Margin = new Thickness(0, 0, 3, 0);

                    carousel.Children.Add(border);
                }
            }

            foreach (var path in FilePath)
            {
                var db = new wesplitEntities();
                image _image = new image();
                _image.id = db.images.Max(x => x.id) + 1;
                _image.idtrip = selectedTrip.id;
                _image.path = path;
                db.images.Add(_image);
                db.SaveChanges();
            }
        }

        private void addRouteClick(object sender, RoutedEventArgs e)
        {
            var editRouteScreen = new EditJourney(selectedTrip.id);
            editRouteScreen.Dying += ScreenClosing;
            this.Hide();
            editRouteScreen.Show();

            oldpath = editRouteScreen.journeyThumbnail.Source.ToString();
        }

        private void addMemberClick(object sender, RoutedEventArgs e)
        {

            var editMemberScreen = new EditMember(selectedTrip.id);
            editMemberScreen.Dying += ScreenClosing;
            this.Hide();
            editMemberScreen.Show();
        }

        private void ScreenClosing()
        {
            selectedTrip = new finalSummary();
            listMember = new List<member>();
            listRoute = new List<route>();
            listRestMoney = new List<restMoney>();
            listImage = new List<image>();
            CreateData(ID);
            BidingData();
            customizeWindow();
            this.Show();
        }


        private void updateDateGoClick(object sender, RoutedEventArgs e)
        {

        }

        private void updateReturnDateClick(object sender, RoutedEventArgs e)
        {

        }

        private void journeyBegDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            journeyEndDate.BlackoutDates.Clear();
            journeyEndDate.SelectedDate = null;
            journeyEndDate.BlackoutDates.Add(new CalendarDateRange(new DateTime(1, 1, 1), (DateTime)journeyBegDate.SelectedDate));

            var temp = db.trips.Where(x => x.id == selectedTrip.id).SingleOrDefault();
            temp.datetogo = journeyBegDate.SelectedDate;
            temp.returndate = journeyEndDate.SelectedDate;
            db.SaveChanges();
        }

        private void journeyEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = db.trips.Where(x => x.id == selectedTrip.id).SingleOrDefault();
            temp.returndate = journeyEndDate.SelectedDate;
            db.SaveChanges();

            // MessageBox.Show(db.trips.Where(x => x.id == selectedTrip.id).First().returndate.ToString());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dying?.Invoke();

            //this.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void mainWindow_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Dying += ScreenClosing;
            this.Hide();
            mainWindow.Show();
        }
    }
}
