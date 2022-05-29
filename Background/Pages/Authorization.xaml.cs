using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Background.DataBase.UnitOfWork;
using Background.Models;
using Validation = Background.MyValidation.Validation;

namespace Background.Pages
{
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("/Pages/RegistrationPage.xaml", UriKind.Relative));
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.ValidateEmail(Email.Text) || !Validation.ValidatePassword(Password.Password))
            {
                MessageBox.Show("Неверный формат логина или пароля");
                return;
            }

            using (var unitOfWork = new UnitOfWork())
            {
                var users = unitOfWork.UsersRepository.GetWithInclude(
                    x => x.Email == Email.Text && x.Password == Password.Password, x => x.Media).ToList();
                if (users.Count == 0)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }

                var user = users.First();
                Account.Id = user.Id;
                Account.Email = user.Email;
                Account.NickName = user.NickName;
                Account.Image = user.Media.ImagePath; // TODO нормальный путь к картинке
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
        }
    }
}