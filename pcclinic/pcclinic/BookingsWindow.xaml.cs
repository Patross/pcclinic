using LiteDB;
using pcclinic.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pcclinic
{
    /// <summary>
    /// Interaction logic for BookingsWindow.xaml
    /// </summary>
    public partial class BookingsWindow : Window
    {
        public BookingsWindow()
        {
            InitializeComponent();
            tblBookings.BeginningEdit += (s, e) => { e.Cancel = true; };
            tblBookings.SelectionChanged += (s, e) => { var a = e.AddedItems; };
            LoadData();
        }
        private void LoadData()
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Booking> bookingCollection = db.GetCollection<Booking>("bookings");

                var query = bookingCollection
                   .Find(x => x.Id >= 1);

                tblBookings.ItemsSource = query;
            }
        }
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }

        private void btnInsertBooking_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Booking> bookingsCollection = db.GetCollection<Booking>("bookings");

                Booking booking = new Booking(txtClientName.Text.ToString(),
                                              DateTime.Parse(txtStartDate.Text.ToString()),
                                              DateTime.Parse(txtDeadline.Text.ToString()),
                                              txtJobType.Text.ToString());

                bookingsCollection.Insert(booking);

                txtClientName.Text = string.Empty;
                txtStartDate.Text = string.Empty;
                txtDeadline.Text = string.Empty;
                txtJobType.Text = string.Empty;
            }
            LoadData();
        }
    }
}
