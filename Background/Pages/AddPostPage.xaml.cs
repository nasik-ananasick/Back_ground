using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Background.DataBase.UnitOfWork;
using Background.Models;
using Microsoft.Win32;

namespace Background.Pages
{
    public partial class AddPostPage : Page
    {
        private Post post;

        public AddPostPage()
        {
            post = new Post();
            InitializeComponent();
        }

        private void AddImage_OnClick(object sender, RoutedEventArgs e)
        {
            var image = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == false) return;

            image = openFileDialog.FileName;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(image);
            bitmapImage.EndInit();
            Image.Source = bitmapImage;
        }

        private void AddPost_OnClick(object sender, RoutedEventArgs e)
        {
            post.Description = Description.Text;
            post.Tags = Tags.Text;
            post.Id = Guid.NewGuid();
            post.UserId = Account.Id;
            var media = new Media()
            {
                Id = Guid.NewGuid(),
                ImagePath = Image.Source.ToString(),
            };
            using (var unit = new UnitOfWork())
            {
                unit.MediaRepository.Create(media);
                post.MediaId = media.Id;
                unit.PostsRepository.Create(post);
            }

            post = new Post();
            Description.Text = "";
            Tags.Text = "";
            Image.Source = null;
            MessageBox.Show("Пост добавлен");
        }
    }
}