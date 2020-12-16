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
using LiveCharts;
using LiveCharts.Wpf;

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
        wesplitEntities1 db = new wesplitEntities1();
        finalSummary selectedTrip = new finalSummary();
        List<member> listMember = new List<member>();
        List<route> listRoute = new List<route>();
        List<restMoney> listRestMoney = new List<restMoney>();
        List<image> listImage = new List<image>();

        
        public DetailWindow(int id)
        {
            InitializeComponent();

            CreateData(id);
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
                 
                }) ; 

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

            listRoute = db.routes.Where(x => x.idtrip == id).ToList();
            listMember = db.members.Where(x => x.idtrip == id).ToList();

            
            //MessageBox.Show(db.members.Where(x => x.idtrip == id).Count().ToString());
        }

        void createDataSelectedTrip(int id)
        {
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
            foreach(var tempMember in listMember)
            {
                restMoney temp = new restMoney();
                temp.name = tempMember.name;
                temp.rest = costForEachMember - (int)tempMember.collectedmoney;
                listRestMoney.Add(temp);
            }

        }

        void createListImage(int id)
        {
            listImage = db.images.Where(x => x.idtrip == id).ToList();
           // MessageBox.Show(listImage.Count().ToString());
        }

        void CreateData (int id)
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
        }

        void customizeWindow()
        {
            journeyName.Text = selectedTrip.name;
            collectedTotalTxt.Text = selectedTrip.totalCollectedMoney.ToString();
            costTotalTxt.Text = selectedTrip.totalCostMoney.ToString();
            dateGoTXT.Text = selectedTrip.datetogo.ToString();
            dateReturnTXT.Text = selectedTrip.returndate.ToString();
           
            var uri = new Uri(getFolder()+$"{selectedTrip.thumbnail}", UriKind.Absolute);
            var bitmap = new BitmapImage(uri);
            thumbnailImage.ImageSource = bitmap;

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

        }

        private void addRouteClick(object sender, RoutedEventArgs e)
        {

        }

        private void addMemberClick(object sender, RoutedEventArgs e)
        {

        }

        private void updateDateGoClick(object sender, RoutedEventArgs e)
        {

        }

        private void updateReturnDateClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
