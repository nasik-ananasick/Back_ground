using System.Windows;
using Background.Pages;

namespace Background
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            AuthorFrame.Navigate(new Authorization());
        }
        
       
        
    }
}