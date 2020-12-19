using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        bool showSplash = true;
        public SplashScreen()
        {
            InitializeComponent();
        }


        static Random _rng = new Random();
        private void DisplayImage(Tuple<string, string, string> images)
        {
            String pathRoot = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine($"{pathRoot}SplashImages/{images.Item1}");
            var bitmap = new BitmapImage(
                        new Uri($"{pathRoot}SplashImages/{images.Item1}",
                        UriKind.Absolute)
                        );
            image.Source = bitmap;
        }

        void DisplaySplashScreen()
        {
            Tuple<string, string, string>[] imagesArray =
            {
                Tuple.Create("bao-tang-lich-su-viet-nam.jpg", "BẢO TÀNG LỊCH SỬ VIỆT NAM", "Nếu là người có niềm đam mê với văn hóa – lịch sử thì hẳn sẽ không thể bỏ qua được địa danh bảo tàng lịch sử Việt Nam. Thực chất tiền thân của nó là viện Bảo tàng Blanchard de la Brosse, được xây vào năm 1929. Nơi sẽ cho bạn được tìm hiểu, chiêm ngưỡng về hàng chục ngàn hiện vật có giá trị. Chưa hết, bảo tàng còn gìn giữ hơn 25.000 sách báo và tài liệu quý về lĩnh vực nghiên cứu khảo cổ học, sử học,… và một các ướp còn nguyên vẹn, kích thích sự tò mò của nhiều người."),
                Tuple.Create("bao-tang-phu-nu-nam-bo.jpg", "BẢO TÀNG PHỤ NỮ NAM BỘ", "Tiền thân của Bảo tàng Phụ nữ Nam Bộ là Nhà truyền thống phụ nữ Nam Bộ, được xây dựng nhằm giữ gìn, giáo dục lòng yêu nước và những truyền thống tốt đẹp của Phụ nữ Việt cho thế hệ sau. Hiện bảo tàng đan quản lý một thư viện gần 10.000 đầu sách, 1 khu trừng bày có diện tích 3.162 m2 với 3 tầng và 8 phòng giới thiệu hiện vật, hình ảnh và tài liệu về các chủ đề: phong trào phụ nữ, truyền thống phụ nữ, Tưởng niệm Hồ Chí Minh, trang phục – trang sức của phụ nữ Việt Nam, phụ nữ Việt Nam trong cuộc sống gi đình."),
                Tuple.Create("ben-nha-rong.jpg", "BẾN NHÀ RỒNG", "Bến Nhà Rồng nơi in dấu hình ảnh vị cha già của dân tộc ra đi tìm đường cứu nước, là chứng nhân cho hai cuộc kháng chiến chống Pháp và chống Mỹ vĩ đại, cũng là một điểm đến không thể bỏ qua khi du lịch Sài Gòn. Tại đây hiện đang trưng bày hàng nghìn hiện vật và tài liệu  cả trong và ngoài trời liên quan tới lịch sử, sự nghiệp hoạt động cách mạng của Bác. Thông qua việc tìm hiểu về bảo tàng du khách sẽ phần nào hiểu hơn về lịch sử dân tộc, quá trình vì nước vì dân của Bác, từ đó thấy yêu và tưởng nhớ hơn đến công đức của người."),
                Tuple.Create("buu-dien.jpg", "BƯU ĐIỆN THÀNH PHỐ", "Được đánh giá là một trong những công trình tuyệt nhất thành phố Hồ Chí Minh, mỗi ngày điểm này đón rất nhiều lượt khách đến tham quan, khám phá. Bưu điện được xây dựng từ năm 1886 – 1891 bởi kiến trúc sư người Pháp, gây ấn tượng với màu vàng nổi rực rỡ trong nắng chiều và những hàng cửa sổ uốn cong, ở chính giữa là chiếc đồng hồ cùng những họa tiết trang trí nhẹ nhàng. Bên trong nổi bật với lối đi màu đỏ của cờ đỏ sao vàng và cách thiết kế nhìn như những thùng rượu khổng lồ,… tất cả thu hút du khách ngay từ lần đầu đặt chân tới."),
                Tuple.Create("cho-ben-thanh.jpg", "CHỢ BẾN THÀNH", "Là cái tên đặc trưng nổi tiếng Sài Gòn, chợ Bến Thành nằm ngay trung tâm thành phố, cả 4 ngõ đều giáp với những con đường lớn. Chợ vừa là nơi giao thương, trao đổi, mua bán hàng hóa vừa là điểm du lịch thu hút nhiều du khách, nhất là khách du lịch nước ngoài."),
                Tuple.Create("chua-buu-long.jpg", "CHÙA BỬU LONG", "Thêm một địa điểm du lịch Sài Gòn đẹp mà nhiều người, nhất là du khách hành hương khó lòng bỏ qua được chiêm ngưỡng ngôi chùa Bửu Long với lối kiến trúc cực kỳ lộng lẫy nhưng cũng không kém phần linh thiêng. Chùa nằm cách trung tâm thành phố khoảng 25 km, được thành lập từ năm 1942, đến năm 2007 được đầu tư, trùng tu lại theo kiểu kết hợp giữa văn hóa Thái Lan, Ấn Độ và kiến trúc nhà Nguyễn."),
                Tuple.Create("dinh-doc-lap.jpg", "DINH ĐỘC LẬP", "Địa điểm đầu tiên phải nhắc đến chính là Dinh Độc Lập hay còn gọi là Hội trường Thống Nhất – chứng nhân cho sự chuyển giao lịch sử giữa hai chế độ và gắn liền với lịch sử của dân tộc Việt Nam. Đây từng là nơi làm việc của bộ máy chính quyền Việt Nam Cộng Hòa và cũng là một trong những di tích đặc biệt cấp quốc gia."),
                Tuple.Create("nha-tho-duc-ba.jpg", "NHÀ THỜ ĐỨC BÀ", "Nhà thờ Đức Bà là một trong những địa điểm du lịch Sài Gòn quận 1, được xem như biểu tượng đặc trưng của thành phố. Tọa lạc ở vị trí trung tâm lý tưởng, thánh đường này nổi bật bởi kiểu kiến trúc châu Âu kết hợp cả phong cách Gothic và Roman với những bức tường gạch màu đỏ hồng, ô kính màu rực rỡ và đôi chuông lớn nhất Việt Nam. Nhà thờ không chỉ là thánh đường sinh hoạt của giáo phận Sài Gòn mà còn là niềm tự hào của người dân thành phố."),
                Tuple.Create("pho-tay.jpg", "PHỐ TÂY BÙI VIỆN", "Nếu Hà Nội có phố bia Tạ Hiện thì Sài Gòn có phố tây Bùi Viện, bởi thế có dịp lang thang thành phố này bạn nhất định phải ghé qua đây. Phố Tây là điểm đến vô cùng hấp dẫn với nhiều hoạt động giải trí và ẩm thực đường phố đặc sắc. Những màn trình diễn nhạc live, pub, bar,… náo nhiệt rất dễ lôi cuốn người khác. Có lẽ đây là một trong những nơi tuyệt vời để bạn cảm nhận được hết cái hồn của một vùng đất mà nhiều người vẫn gọi là thành phố không ngủ."),
            };

            int randomNumber = _rng.Next(6);

            DisplayImage(imagesArray[randomNumber]);
            PlaceName.Text = imagesArray[randomNumber].Item2;
            PlaceContent.Text = imagesArray[randomNumber].Item3;
        }

        private void ScreenClosing()
        {
            this.Show();
        }
        private void continue_click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Dying += ScreenClosing;
            this.Hide();
            mainWindow.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings["ShowSplashScreen"].Value = "false";
            //config.Save(ConfigurationSaveMode.Full);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var value = ConfigurationManager.AppSettings["ShowSplashScreen"];
            //showSplash = bool.Parse(value);
            //Debug.WriteLine(value);
            //if (showSplash == false)
            //{
            //    DisplaySplashScreen();
            //    var screen = new MainWindow(); //window2 == homescreen
            //    this.Close();
            //    screen.ShowDialog();
            //}
            //else
            //{
            //    DisplaySplashScreen();
            //}
            DisplaySplashScreen();
        }
    }
}
