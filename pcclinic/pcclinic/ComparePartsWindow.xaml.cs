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
    /// Interaction logic for ComparePartsWindow.xaml
    /// </summary>
    public partial class ComparePartsWindow : Window
    {
        public ComparePartsWindow()
        {
            InitializeComponent();
            comboItem1.SelectionChanged += comboItemSelection_Changed;
            comboItem2.SelectionChanged += comboItemSelection_Changed;

            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Inventory> customersCollection = db.GetCollection<Inventory>("inventory");

                var query = customersCollection
                   .Find(x => x.Id >= 1);

                foreach (var item in query)
                {
                    comboItem1.Items.Add(item.Id + ") " + item.ItemName);
                    comboItem2.Items.Add(item.Id + ") " + item.ItemName);
                }
            }
        }

        private void comboItemSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (comboItem1.SelectedIndex != -1 & comboItem2.SelectedIndex != -1)
            {
                using (var db = new LiteDatabase("pcclinic.db"))
                {
                    LiteCollection<Inventory> inventoryCollection = db.GetCollection<Inventory>("inventory");
                    IEnumerable<Inventory> itemId = inventoryCollection.Find(x => x.Id == int.Parse(comboItem1.SelectedValue.ToString().ToCharArray()[0].ToString()));
                    foreach (var item in itemId)
                    {

                        lblName1.Content = item.ItemName.ToString();
                        lblType1.Content = item.ItemDescription;
                        lblQuantity1.Content = item.ItemQuantity;
                        lblValue1.Content = item.ItemValue;
                    }
                    var itemId2 = inventoryCollection.Find(x => x.Id == int.Parse(comboItem2.SelectedValue.ToString().ToCharArray()[0].ToString()));
                    foreach (var item in itemId2)
                    {

                        lblName2.Content = item.ItemName;
                        lblType2.Content = item.ItemDescription;
                        lblQuantity2.Content = item.ItemQuantity;
                        lblValue2.Content = item.ItemValue;
                    }


                    //lblName1.Content = comboItem1.SelectedValue.ToString(); lblName2.Content = comboItem2.SelectedValue;
                    //lblType1.Content = comboItem1.SelectedValue.ToString(); lblType2.Content = comboItem2.SelectedValue;
                    //lblQuantity1.Content = comboItem1.SelectedValue.ToString(); lblQuantity2.Content = comboItem2.SelectedValue;
                    //lblValue1.Content = comboItem1.SelectedValue.ToString(); lblValue2.Content = comboItem2.SelectedValue;
                }
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }
    }
}
