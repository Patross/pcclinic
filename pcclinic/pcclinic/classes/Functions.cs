﻿using System;
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
            window.Height = 350;
            window.Width = 525;
            window.Show();
        }
    }
}
