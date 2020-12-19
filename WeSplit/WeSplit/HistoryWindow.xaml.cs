using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public delegate void DeathHandler();
        public event DeathHandler Dying;

        wesplitEntities db = new wesplitEntities();
        public static ListView data;

        public string connectionString = "Server=.\\SQLEXPRESS;Database=wesplit;Trusted_Connection=True;";

        public List<trip> NotFinishTrip = new List<trip>();
        public List<trip> allTrip = new List<trip>();

        public int radioTag = 0;

        public HistoryWindow()
        {
            InitializeComponent();

            allTrip = db.trips.ToList();
            //NotFinishTrip.Add(allTrip.Find(x => x.isfinish == false));Know, Remember, Forget
            for (int i = 0; i < allTrip.Count(); i++)
            {
                if (allTrip[i].isfinish == true)
                {
                    NotFinishTrip.Add(allTrip[i]);
                }
            }

            tripdata.ItemsSource = NotFinishTrip;
            data = tripdata;
        }


        //function show detail window of 1 trip when clicked
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            var x = (item as trip).id;

            var detail = new DetailWindow(x);
            this.Hide();
            detail.Show();
        }

        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        public static string filterVietNameseTone(string str)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }

        //catch search event
        private void search_Press(object sender, KeyEventArgs e)
        {
            if (radioTag == 0)
            {
                MessageBox.Show("Hãy chọn 1 trong hai lựa chọn để tìm kiếm!!!");
                searchTextBox.Clear();
            }
            else if (radioTag == 1)
            {
                tripdata.ItemsSource = SearchByPlaceName(connectionString);
            }
            else if (radioTag == 2)
            {
                tripdata.ItemsSource = SearchByMemberName(connectionString);
            }
        }

        public List<trip> SearchByPlaceName(string connectionString)
        {
            string queryString = "select * from trip join places on trip.idplace = places.id where isfinish = 1;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<trip> res = new List<trip>();
                string placeName;
                int index;

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        placeName = reader[10].ToString();
                        index = (int)reader[0];

                        if (filterVietNameseTone(placeName).ToUpper().Contains(filterVietNameseTone(searchTextBox.Text.ToUpper())))
                        {
                            res.Add(NotFinishTrip.Find(x => x.id == index));
                        }
                    }
                }
                connection.Close();
                return res;
            }
        }

        public List<trip> SearchByMemberName(string connectionString)
        {
            string queryString = "select * from trip join member on trip.id = member.idtrip where isfinish = 1;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<trip> res = new List<trip>();
                string memberName;
                int index;

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        memberName = reader[10].ToString();
                        index = (int)reader[0];

                        if (filterVietNameseTone(memberName).ToUpper().Contains(filterVietNameseTone(searchTextBox.Text.ToUpper())))
                        {
                            if (!res.Contains(NotFinishTrip.Find(x => x.id == index)))
                            {
                                res.Add(NotFinishTrip.Find(x => x.id == index));
                            }
                        }
                    }
                }
                connection.Close();
                return res;
            }
        }

        private void checkChosenEvent(object sender, RoutedEventArgs e)
        {
            var senderObj = (RadioButton)sender;
            radioTag = Convert.ToInt32(senderObj.Tag);
        }

        private void addJourney_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var addJourneyScreen = new EditJourney();
            addJourneyScreen.Dying += ScreenClosing;
            this.Hide();
            addJourneyScreen.Show();
        }

        private void ScreenClosing()
        {
            this.Show();
        }

        //open place window tab
        private void placeWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var placesWindow = new PlacesWindow();
            placesWindow.Dying += ScreenClosing;
            this.Hide();
            placesWindow.Show();
        }

        /*        private void mainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Dying += ScreenClosing;
                    this.Hide();
                    mainWindow.Show();
                }*/

        private void mainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dying?.Invoke();
        }
    }
}
