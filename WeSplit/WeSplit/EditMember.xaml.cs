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
    public partial class EditMember : Window
    {
        public delegate void DeathHandler();
        public event DeathHandler Dying;
        int idTrip = -1;
        public BindingList<member> _members;
        trip _trip = null;
        String newPath = "";
        String oldPath = "";
        public EditMember(int id)
        {
            InitializeComponent();
            idTrip = id;

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dying?.Invoke();
        }
        public EditMember()
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
                addMemberAddNew_Click(sender, e);
                addMemberEdit.IsEnabled = false;
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
                _members = new BindingList<member>(_trip.members.ToList());
                memberNameEdit.ItemsSource = _members;
                memberList.ItemsSource = _members;
                journeyThumbnail.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + _trip.thumbnail, UriKind.Absolute));
                journeyEndDate.BlackoutDates.Add(new CalendarDateRange(new DateTime(1, 1, 1), (DateTime)journeyBegDate.SelectedDate));
            }
        }

        private void routeName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (memberNameEdit.SelectedItem != null)
            {
                memberMoney.Text = ((member)memberNameEdit.SelectedItem).collectedmoney.ToString();
                memberPhone.Text = ((member)memberNameEdit.SelectedItem).phonenumber;
            }
        }

        private void finishEditJourney_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void addMemberAddNew_Click(object sender, RoutedEventArgs e)
        {
            memberNameEdit.Visibility = Visibility.Collapsed;
            memberNameAddNew.Visibility = Visibility.Visible;
            addMemberAddNew.Visibility = Visibility.Collapsed;
            addMemberEdit.Visibility = Visibility.Visible;
            memberMoney.Text = "";
        }
        private void saveMember_Click(object sender, RoutedEventArgs e)
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

            if (memberMoney.Text.Equals(""))
            {
                Err.Foreground = Brushes.Red;
                Err.Text = "Hãy bổ sung trường tiền thu";
                return;
            }

            if (memberPhone.Text.Equals(""))
            {
                Err.Foreground = Brushes.Red;
                Err.Text = "Hãy bổ sung trường số điện thoại";
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
                Err.Text = "Đã cập nhật thông tin chuyến đi";


                if (memberNameEdit.Visibility == Visibility.Visible && memberNameEdit.SelectedIndex != -1)
                {
                    var id = ((member)memberNameEdit.SelectedItem).id;
                    var oldMember = db.members.Find(id);
                    oldMember.collectedmoney = int.Parse(memberMoney.Text);
                    oldMember.phonenumber = memberPhone.Text;
                    db.SaveChanges();
                    Err.Foreground = Brushes.Green;
                    Err.Text = "Da cap nhat thong tin thanh vien";
                }
                else if (memberNameAddNew.Visibility == Visibility.Visible)
                {
                    if (memberNameAddNew.Text.Equals(""))
                    {
                        Err.Foreground = Brushes.Red;
                        Err.Text = "Hay them ten thanh vien";
                        return;
                    }

                    var maxId = db.members.Max(x => x.id);
                    member newMember = new member();
                    newMember.id = maxId + 1;
                    newMember.idtrip = idTrip;
                    newMember.collectedmoney = int.Parse(memberMoney.Text);
                    newMember.name = memberNameAddNew.Text;
                    newMember.phonenumber = memberPhone.Text;
                    db.members.Add(newMember);
                    Err.Foreground = Brushes.Green;
                    Err.Text = "Da them moi thanh vien";
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

                    if (memberNameAddNew.Text.Equals(""))
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
                var _memberName = memberNameAddNew.Text;
                var _memberMoney = int.Parse(memberMoney.Text);
                //var _routeDescription = routeDescription.Text;
                member newMember = new member();
                newMember.id = db.routes.Max(x => x.id) + 1;
                newMember.idtrip = _trip.id;
                newMember.collectedmoney = _memberMoney;
                newMember.name = _memberName;
                db.members.Add(newMember);
                Err.Foreground = Brushes.Green;
                Err.Text = "Da them moi thanh vien";
                db.SaveChanges();
                memberNameAddNew.Text = "";
                memberMoney.Text = "";

            }
            _members = new BindingList<member>(db.members.Where(x => x.idtrip == _trip.id || x.idtrip == idTrip).ToList());
            memberList.ItemsSource = _members;
            var tmp = memberNameEdit.SelectedIndex;
            memberNameEdit.ItemsSource = _members;
            memberNameEdit.SelectedIndex = tmp;
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
                var money = int.Parse(memberMoney.Text);
                Err.Text = "";
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Err.Text = "Tien la so nguyen";
                memberMoney.Text = "";
                //routeMoney.Focus();
            }
        }

        private void memberPhonne_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var phone = int.Parse(memberPhone.Text);
                Err.Text = "";
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Err.Text = "SDT phai la day so nguyen";
                memberPhone.Text = "";
                //routeMoney.Focus();
            }
        }

        private void addMemberEdit_Click(object sender, RoutedEventArgs e)
        {
            memberNameEdit.Visibility = Visibility.Visible;
            memberNameAddNew.Visibility = Visibility.Collapsed;
            addMemberAddNew.Visibility = Visibility.Visible;
            addMemberEdit.Visibility = Visibility.Collapsed;
            if (memberNameEdit.SelectedItem != null)
                memberMoney.Text = ((member)memberNameEdit.SelectedItem).collectedmoney.ToString();
            memberNameAddNew.Text = "";
        }
    }
}
