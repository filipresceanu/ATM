using ATM;
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
    /// Interaction logic for OpenAccount.xaml
    /// </summary>
    public partial class OpenAccount : Window
    {
      
        DataAccess access = new DataAccess();
        ContBancar cont = new ContBancar();
        int tipCont;
        private Client _client;
        public OpenAccount(Client client)
        {
            InitializeComponent();
            
            this._client = client;
        }
        private void cmbTipCont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              int item = (int)cmbTipCont.SelectedIndex + 1;
              tipCont = item;
        }

        

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                access.Add_ContBancar(_client, tipCont, cont);
                MessageBox.Show("PIN :" + cont.PIN);
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Moneda sau Tipul de cont nu au fost selectate");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              ComboBoxItem comb = (ComboBoxItem)cmbMoneda.SelectedItem;
              cont.Moneda = comb.Content.ToString();
        }
    }
}
