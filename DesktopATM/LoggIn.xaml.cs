using ATM;
using ClassLibrary1;
using Functii;
using Operati_BANCARE;
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

namespace DesktopATM
{
    /// <summary>
    /// Interaction logic for LoggIn.xaml
    /// </summary>
    public partial class LoggIn : Window
    {
        Tranzacti tranzacti = new Tranzacti();
        private ContBancar _cont;
        DataAccess access = new DataAccess();
        public LoggIn(ContBancar cont)
        {
            InitializeComponent();
            this._cont = cont;
        }

        private void Sold_Click(object sender, RoutedEventArgs e)
        {
                   
            access.updateSold(_cont.TotalSold, _cont.ID);
            lblSold.Content = _cont.TotalSold;

        }
       
        private void Retragere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    _cont.RetragereNumerar((float)Convert.ToInt32(txtRetragere.Text));
                    access.updateSold(_cont.TotalSold,(int) _cont.ID);
                    tranzacti.operatia = "Retragere";
                    tranzacti.dateTime = DateTime.Today;
                    tranzacti.cont.ID = _cont.ID;
                    tranzacti.Sold = (float)Convert.ToInt32(txtRetragere.Text);
                    access.insertTranzactii(tranzacti);
                    lblSold.Content = _cont.TotalSold;
            }
            catch
            {
                MessageBox.Show("Suma nu a fost introdusa");
            }
        }

        private void Depunere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _cont.DepunereNumerar((float)Convert.ToInt32(txtDepunere.Text));
                access.updateSold(_cont.TotalSold, _cont.ID);
                tranzacti.operatia = "Depunere";
                tranzacti.dateTime = DateTime.Today;
                tranzacti.cont.ID = _cont.ID;
                tranzacti.Sold = float.Parse(txtDepunere.Text);
                access.insertTranzactii(tranzacti);
                lblSold.Content = _cont.TotalSold;
            }
            catch
            {
                MessageBox.Show("Suma nu a fost introdusa");
            }
        }

        private void SchimbPIN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _cont.SchimbPIN(Convert.ToInt32(txtSchimbarePIN.Text));
                access.schimbPIN(Convert.ToInt32(txtSchimbarePIN.Text), _cont.ID);
                lblNewPIN.Content = _cont.PIN;
            }
            catch
            {
                MessageBox.Show("PIN-ul nu a fost introdus");
            }

            
        }
    }
}
