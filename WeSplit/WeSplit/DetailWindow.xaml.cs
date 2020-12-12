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
    public partial class DetailWindow : Window
    {
        public class chuyenDi
        {
            string ngayDi { get; set; }
            string ngayVe { get; set; }
            string tenChuyenDi { get; set; }

        }

        public class thanhVien
        {
            public string hoTen { get; set; }
            public string sdt { get; set; }
            public string tienThu { get; set; }
            public string conLai { get; set; }

        }

        public class lichTrinh
        {
            public string diaDiem { get; set; }
            public string tienChi { get; set; }
        }

        List<thanhVien> listThanhVien = new List<thanhVien>();
        List<lichTrinh> listLichTrinh = new List<lichTrinh>();
        public DetailWindow()
        {
            InitializeComponent();

            getData();

            lvDiaDiem.ItemsSource = listLichTrinh;

            lvTienConLai.ItemsSource = listThanhVien;

            lvTienThu.ItemsSource = listThanhVien;

         

            customizePieChart();
        }

        void getData()
        {
            listThanhVien.Add(new thanhVien() { hoTen = "duong boi long", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });
            listThanhVien.Add(new thanhVien() { hoTen = "duong boi long", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });
            listThanhVien.Add(new thanhVien() { hoTen = "duong boi long", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });
            listThanhVien.Add(new thanhVien() { hoTen = "duong boi long", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });
            listThanhVien.Add(new thanhVien() { hoTen = "BO BO", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });
            listThanhVien.Add(new thanhVien() { hoTen = "winter", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });
            listThanhVien.Add(new thanhVien() { hoTen = "winter cuteeeee", sdt = "0976942124", tienThu = "1000000", conLai = "2000000" });


            listLichTrinh.Add(new lichTrinh() { diaDiem = "tien giang", tienChi = "1000000" });
            listLichTrinh.Add(new lichTrinh() { diaDiem = "can tho", tienChi = "1000000" });
            listLichTrinh.Add(new lichTrinh() { diaDiem = "thanh pho ho chi minh", tienChi = "1000000"});

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

            foreach (thanhVien tempThanhVien in listThanhVien)
            {
                piechartData.Add(new PieSeries
                {
                    Title = tempThanhVien.hoTen,
                    Values = new ChartValues<float> { float.Parse(tempThanhVien.tienThu) },
                    // DataLabels = true
                    // LabelPoint = labelPoint
                });

            }

            tienThuPie.Series = piechartData;
        }
        void customizeTienChiChart()
        {
            SeriesCollection piechartData = new SeriesCollection();

            foreach (lichTrinh tempLichTrinh in listLichTrinh)
            {
                piechartData.Add(new PieSeries
                {
                    Title = tempLichTrinh.diaDiem,
                    Values = new ChartValues<float> { float.Parse(tempLichTrinh.tienChi) },
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

        void createListImage()
        {
            var grid_temp = new Grid();
            var boder = new Border();
            boder.CornerRadius = new CornerRadius(15);
            var temp = new ImageBrush();
            boder.Width = 110;
            boder.Height = 110;
            grid_temp.Margin = new Thickness(2);
            listImageView.Children.Add(grid_temp);
        }

        

        private void EndClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
