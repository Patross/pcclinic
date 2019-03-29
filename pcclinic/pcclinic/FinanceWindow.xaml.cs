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
    /// Interaction logic for FinanceWindow.xaml
    /// </summary>
    public partial class FinanceWindow : Window
    {
        public FinanceWindow()
        {
            InitializeComponent();

            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Finance> financeCollection = db.GetCollection<Finance>("finances");
                string query;
                try
                {
                    query = financeCollection.FindById(1).Money.ToString();
                }
                catch (NullReferenceException)
                {
                    //
                    LiteCollection<Finance> financeCOllection = db.GetCollection<Finance>("finances");

                    Finance finance = new Finance(0m);

                    financeCollection.Insert(finance);
                    query = financeCOllection.FindById(1).Money.ToString();

                }

                lblMoney.Content = "Money: £" + query;
            }
        }
        private void LoadData()
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Finance> financeCollection = db.GetCollection<Finance>("finances");

                lblMoney.Content = "Money: £" + financeCollection.FindById(1).Money;
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenWindow(this, new MainWindow());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Finance> financeCollection = db.GetCollection<Finance>("finances");

                var money = financeCollection.FindById(1);

                money.Money = money.Money + decimal.Parse(txtMoney.Text.ToString());
                financeCollection.Update(money);

                LoadData();
            }

        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("pcclinic.db"))
            {
                LiteCollection<Finance> financeCollection = db.GetCollection<Finance>("finances");

                var money = financeCollection.FindById(1);

                money.Money = money.Money - decimal.Parse(txtMoney.Text.ToString());
                financeCollection.Update(money);

                LoadData();
            }
        }
    }
}
