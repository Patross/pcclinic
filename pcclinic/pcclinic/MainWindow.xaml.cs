using pcclinic.classes;
using System.Windows;


namespace pcclinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Navigation
        private void btnOpenClients_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new ClientsWindow());
        }

        private void btnOpenInventory_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new InventoryWindow());
        }

        private void btnOpenJobs_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new JobsWindow());
        }

        private void btnOpenBookings_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new BookingsWindow());
        }

        private void btnOpenCompareParts_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new ComparePartsWindow());
        }

        private void btnOpenFinance_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new FinanceWindow());
        }
        #endregion
    }
}
