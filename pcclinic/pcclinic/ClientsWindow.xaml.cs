using pcclinic.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using LiteDB;

namespace pcclinic
{
    /// <summary>
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {

        public ClientsWindow()
        {
            InitializeComponent();
            tblClients.BeginningEdit += (s, e) => { e.Cancel = true; };
            tblClients.SelectionChanged += (s, e) => { var a = e.AddedItems; };
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Customer> customersCollection = db.GetCollection<Customer>("customers");
                LiteCollection<Customer> customerFirstName = customersCollection.Include(x => x.FirstName);

                var query = customersCollection
                    .Include(x => x.FirstName)
                   .Include(x => x.LastName)
                   .Find(x => x.Id >= 1);

                tblClients.ItemsSource = query;
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }

        private void btnInsertClient_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Customer> customersCollection = db.GetCollection<Customer>("customers");

                Customer customer = new Customer(firstName: txtFirstName.Text.ToString(),
                                                 lastName: txtLastName.Text.ToString(),
                                                 email: txtEmail.Text.ToString(),
                                                 telephone: txtTelephone.Text.ToString());

                customersCollection.Insert(customer);

                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelephone.Text = string.Empty;
            }
            LoadData();
        }
    }
}
