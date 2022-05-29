using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Background.MyValidation
{
    public static class Validation
    {
        private static readonly Regex EmailRegex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+" +
                                                             @"\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        public static bool ValidateEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);
        }
        public static bool ValidatePassword(string password)
        {
            return password.Length >= 6;
        }
    }
}