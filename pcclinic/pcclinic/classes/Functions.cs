using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pcclinic.classes
{
    static class Functions
    {
        public static void OpenWindow(Window currentWindow, Window newWindow)
        {
            currentWindow.Close();
            Window window = newWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Height = 400;
            window.Width = 725;
            window.Show();
        }

        public static string GetUntilOrEmpty(this string text, string stopAt = ")")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }
}
