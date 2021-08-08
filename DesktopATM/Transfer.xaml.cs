using ATM;
using ClassLibrary1;
using Operati_BANCARE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        DataAccess dataAccess = new DataAccess();
        private ContBancar _cont;
        Convertor convertor = new Convertor();
        public Transfer(ContBancar cont)
        {
            InitializeComponent();
            this._cont = cont;
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtIBAN.Text=="" ||txtTransfer.Text=="")
                {
                    throw new Exception();
                }
                Tranzacti tranzacti = new Tranzacti();
                ContBancar bancar = dataAccess.GetTipCont(txtIBAN.Text.ToString());
                tranzacti.dateTime = DateTime.Today;
                tranzacti.operatia = "Transfer";
                tranzacti.cont.ID = _cont.ID;
                tranzacti.contDestinatie = bancar.ID;

                tranzacti.Sold = (float)Convert.ToInt32(txtTransfer.Text);
                dataAccess.insertTranzactii(tranzacti);
                _cont.Transfer((float)Convert.ToInt32(txtTransfer.Text));
                dataAccess.updateSold(_cont.TotalSold, (int)_cont.ID);
                tranzacti = new Tranzacti();
                if (bancar.Moneda == _cont.Moneda)
                {
                    tranzacti.Sold = (float)Convert.ToInt32(txtTransfer.Text);
                }
                if (bancar.Moneda == "EURO" && _cont.Moneda == "RON")
                {
                    tranzacti.Sold = await convertor.Euro_RonAsync((float)Convert.ToInt32(txtTransfer.Text));
                }
                if (bancar.Moneda == "RON" && _cont.Moneda == "EURO")
                {
                    tranzacti.Sold = await convertor.ron_euro((float)Convert.ToInt32(txtTransfer.Text));
                }
                tranzacti.dateTime = DateTime.Now;
                tranzacti.operatia = "Transfer";
                tranzacti.cont.ID = bancar.ID;
                tranzacti.contDestinatie = _cont.ID;

               
                dataAccess.insertTranzactii(tranzacti);

                if (_cont.Moneda == bancar.Moneda) //if both accounts have the same currency
                {
                    bancar.DepunereNumerar((float)Convert.ToInt32(txtTransfer.Text));
                    dataAccess.updateSold(bancar.TotalSold, (int)bancar.ID);
                }
                if (bancar.Moneda == "EURO" && _cont.Moneda == "RON")
                {
                    float number = await convertor.Euro_RonAsync((float)Convert.ToInt32(txtTransfer.Text));
                    bancar.DepunereNumerar(number);
                    dataAccess.updateSold(bancar.TotalSold, (int)bancar.ID);
                }
                if (bancar.Moneda == "RON" && _cont.Moneda == "EURO")
                {
                    bancar.DepunereNumerar(await convertor.ron_euro((float)Convert.ToInt32(txtTransfer.Text)));
                    dataAccess.updateSold(bancar.TotalSold, (int)bancar.ID);
                }
            }
            catch
            {
                MessageBox.Show("IBAN sau moneda nu au fost introduse");
            }
            this.Close();
        }

        

        private void txtIBAN_GotFocus(object sender, RoutedEventArgs e)
        {
            
            txtIBAN.Text = "";

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
