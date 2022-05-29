using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Background.DataBase.UnitOfWork;
using Background.Models;

namespace Background.Pages
{
    public partial class RedactPage : Page
    {
        public RedactPage()
        {
            InitializeComponent();
            Nick.Text = Account.NickName;
            DoubleAnimation buttonAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.7)
            };
            this.BeginAnimation(FrameworkElement.OpacityProperty, buttonAnimation);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Nick.Text.Length > 0)
            {
                if (OldPassword.Password != "" && NewPassword.Password != "" && RepeatPassword.Password != "" &&
                    !PasswordGrid.IsEnabled)
                {
                    if (!ChangePassword())
                    {
                        // TODO сделать так, чтобы становилоась активной и нельзя кликать на применить изменения возможно через еще одну переменную
                        // PasswordGrid.IsEnabled = true;
                        // PasswordGrid.Opacity = 1;
                        return;
                    }
                }

                using (var unit = new UnitOfWork())
                {
                    var user = unit.UsersRepository.Get(Account.Id);
                    user.NickName = Nick.Text;
                    unit.UsersRepository.Update(user);
                }

                ProfilePage.ReductPageIsOpen = false;
                NavigationService?.Navigate(new Uri("Pages/AccInfoPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Введите никнейм");
            }
        }

        private bool ChangePassword()
        {
            if (OldPassword.Password == "" || NewPassword.Password == "" || RepeatPassword.Password == "")
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }

            if (NewPassword.Password != RepeatPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }

            using (var unit = new UnitOfWork())
            {
                var user = unit.UsersRepository.Get(Account.Id);
                if (user.Password != OldPassword.Password)
                {
                    MessageBox.Show("Неверный пароль");
                    return false;
                }

                user.Password = NewPassword.Password;
                unit.UsersRepository.Update(user);
            }

            MessageBox.Show("Пароль изменен");
            return true;
        }


        private void RedactPassword(object sender, RoutedEventArgs e)
        {
            if (PasswordGrid.IsEnabled)
            {
                PasswordGrid.Opacity = 0.5;
                PasswordGrid.IsEnabled = false;
            }
            else
            {
                PasswordGrid.Opacity = 1;
                PasswordGrid.IsEnabled = true;
            }
        }
    }
}