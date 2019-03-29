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
    /// Interaction logic for JobsWindow.xaml
    /// </summary>
    public partial class JobsWindow : Window
    {
        public JobsWindow()
        {
            InitializeComponent();
            tblJobs.BeginningEdit += (s, e) => { e.Cancel = true; };
            tblJobs.SelectionChanged += (s, e) => { var a = e.AddedItems; };
            LoadData();
        }
        private void LoadData()
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Job> customersCollection = db.GetCollection<Job>("jobs");

                var query = customersCollection
                   .Find(x => x.Id >= 1);

                tblJobs.ItemsSource = query;
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }

        private void btnInsertJob_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Job> customersCollection = db.GetCollection<Job>("jobs");

                Job job = new Job(txtJobType.Text.ToString(),
                                  txtClientId.Text.ToString(),
                                  DateTime.Parse(txtDeadline.Text.ToString()),
                                  txtDeviceType.Text.ToString());

                customersCollection.Insert(job);

                txtJobType.Text = string.Empty;
                txtClientId.Text = string.Empty;
                txtDeadline.Text = string.Empty;
                txtDeviceType.Text = string.Empty;
            }
            LoadData();
        }
    }
}
