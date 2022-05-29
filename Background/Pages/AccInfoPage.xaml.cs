using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Background.DataBase.UnitOfWork;
using Background.Models;

namespace Background.Pages
{
    public partial class AccInfoPage : Page
    {
        public AccInfoPage()
        {
            InitializeComponent();
            DoubleAnimation buttonAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.7)
            };
            this.BeginAnimation(FrameworkElement.OpacityProperty, buttonAnimation);
            using (var unit = new UnitOfWork())
            {
                var user = unit.UsersRepository.Get(Account.Id);
                Account.Email = user.Email;
                Account.NickName = user.NickName;
            }

            AccountEmail.Text = Account.Email;
            AccountNickName.Text = Account.NickName;
        }
    }
}