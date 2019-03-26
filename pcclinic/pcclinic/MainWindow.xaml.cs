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
            ClientsWindow w = new ClientsWindow();
            w.Show();
            this.Close();
        }

        private void btnOpenInventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryWindow w = new InventoryWindow();
            w.Show();
            this.Close();
        }

        private void btnOpenJobs_Click(object sender, RoutedEventArgs e)
        {
            JobsWindow w = new JobsWindow();
            w.Show();
            this.Close();
        }

        private void btnOpenBookings_Click(object sender, RoutedEventArgs e)
        {
            BookingsWindow w = new BookingsWindow();
            w.Show();
            this.Close();
        }

        private void btnOpenCompareParts_Click(object sender, RoutedEventArgs e)
        {
            ComparePartsWindow w = new ComparePartsWindow();
            w.Show();
            this.Close();
        }

        private void btnOpenFinance_Click(object sender, RoutedEventArgs e)
        {
            FinanceWindow w = new FinanceWindow();
            w.Show();
            this.Close();
        }
        #endregion
    }
}
