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
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public InventoryWindow()
        {
            InitializeComponent();
            tblInventory.BeginningEdit += (s, e) => { e.Cancel = true; };
            tblInventory.SelectionChanged += (s, e) => { var a = e.AddedItems; };
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Inventory> customersCollection = db.GetCollection<Inventory>("inventory");
                //LiteCollection<Inventory> customerFirstName = customersCollection.Include(x => x.FirstName);

                var query = customersCollection
                   .Find(x => x.Id >= 1);

                tblInventory.ItemsSource = query;
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }

        private void btnInsertItem_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Inventory> customersCollection = db.GetCollection<Inventory>("inventory");

                Inventory inventory = new Inventory(itemName: txtItemName.Text.ToString(),
                                                 itemDescription: txtItemDescription.Text.ToString(),
                                                 itemQuantity: txtQuantity.Text.ToString(),
                                                 itemValue: txtValue.Text.ToString());

                customersCollection.Insert(inventory);

                txtItemName.Text = string.Empty;
                txtItemDescription.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtValue.Text = string.Empty;
            }
            LoadData();
        }
    }
}
