using System;
using System.Windows.Media;

namespace Background.Models
{
    public static class Account
    {
        public static Guid Id { get; set; }
        public static string Email { get; set; }
        public static string NickName { get; set; }
        public static string Image { get; set; }
        public static ImageSource ImageSource { get; set; }
    }
}