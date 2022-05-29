using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Background.DataBase.UnitOfWork;
using Background.Models;
using Microsoft.Win32;

namespace Background.Pages
{
    public partial class ProfilePage : Page
    {
        public static bool ReductPageIsOpen;
        private ObservableCollection<Post> Posts { get; set; }


        public ProfilePage()
        {
            InitializeComponent();
            using (var unitOfWork = new UnitOfWork())
            {
                Posts = new ObservableCollection<Post>(
                    unitOfWork.PostsRepository.GetWithInclude(x => x.UserId == Account.Id, x => x.Media));
                ListBoxPosts.ItemsSource = Posts;
            }

            if (Account.Image.Equals(""))
            {
                var l = (BitmapImage)FindResource("DefAccIcon");
                ImageBrush.ImageSource = l;
            }
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(Account.Image);
                bitmapImage.EndInit();
                ImageBrush.ImageSource = bitmapImage;
            }
        }

        private void Avatar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() != true)
                return;
            image = openFileDialog.FileName;
            using (var unitOfWork = new UnitOfWork())
            {
                var user = unitOfWork.UsersRepository.Get(Account.Id);
                var media = unitOfWork.MediaRepository.Get((Guid)user.MediaId);
                media.ImagePath = image;
                unitOfWork.MediaRepository.Update(media);
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(image);
            bitmapImage.EndInit();
            ImageBrush.ImageSource = bitmapImage;
        }

        private void RedactionButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ReductPageIsOpen)
            {
                ReductPageIsOpen = false;
                RedactFrame.Navigate(new AccInfoPage());
            }

            else
            {
                ReductPageIsOpen = true;
                RedactFrame.Navigate(new RedactPage());
            }
        }
    }
}