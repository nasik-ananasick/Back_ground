using System.Windows;
using Background.DataBase.UnitOfWork;
using Background.Models;
using Background.Pages;

namespace Background
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TimelinePage());
        }

        private void ProfileButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }

        private void AddPostButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddPostPage());
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TimelinePage());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LikedPostsPage());
        }
    }
}