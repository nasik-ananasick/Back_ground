using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Background.DataBase.UnitOfWork;
using Background.Models;
using Background.MyValidation;
using Validation = Background.MyValidation.Validation;

namespace Background.Pages
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("/Pages/Authorization.xaml", UriKind.Relative));
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.ValidateEmail(Email.Text))
            {
                MessageBox.Show("Инвалидный логин");
                return;
            }
            else if (!Validation.ValidatePassword(Password.Password) ||
                     !Validation.ValidatePassword(ConfirmPassword.Password))
            {
                MessageBox.Show("Инвалидный пароль");
                return;
            }
            else if (Password.Password != ConfirmPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            
            using (var unitOfWork = new UnitOfWork())
            {
                var media = new Media()
                {
                    Id = Guid.NewGuid(),
                    ImagePath = "",
                };
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    NickName = Email.Text,
                    Password = Password.Password,
                    Email = Email.Text,
                    IsModer = false,
                    MediaId = media.Id,
                };
                unitOfWork.MediaRepository.Create(media);
                unitOfWork.UsersRepository.Create(user);
                Account.Id = user.Id;
                Account.Email = user.Email;
                Account.NickName = user.NickName;
                Account.Image = "";
            }
            
            var mainWindow = new MainWindow();
            mainWindow.Show();
            foreach (var window in Application.Current.Windows) //TODO лучше потестить
            {
                if (window.GetType() == typeof(AuthorizationWindow))
                {
                    ((AuthorizationWindow)window).Close();
                    return;
                }
            }
            //NavigationService?.Navigate(new Uri("/Pages/TimelinePage.xaml", UriKind.Relative));
        }
    }
}