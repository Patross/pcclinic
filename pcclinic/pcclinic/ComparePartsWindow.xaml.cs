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

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }
    }
}
