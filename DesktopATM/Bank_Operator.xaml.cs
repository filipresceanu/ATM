using ATM;
using Functii;
using Operati_BANCARE;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Text.RegularExpressions;

namespace DesktopATM
{
    /// <summary>
    /// Interaction logic for Bank_Operator.xaml
    /// </summary>
    public partial class Bank_Operator : Window
    {
        DataAccess access = new DataAccess();
       
        public Bank_Operator()
        {
            InitializeComponent();
                        
            datagrid.ItemsSource = access.GetClients();
        }

       

        private void AfisareClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = (Client)datagrid.SelectedItem;
                if(client==null)
                {
                    throw new Exception();
                }
                contdatagrid.ItemsSource = access.GetContBancars(client.ID);
            }
            catch
            {
                MessageBox.Show("Clientul nu a fost selectat");
            }
        }

       

        private void Inchidere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContBancar contBancar;
                  contBancar = (ContBancar)contdatagrid.SelectedItem;
                if(contBancar==null)
                {
                    throw new Exception();
                }
                  access.DeleteAccount((int)contBancar.ID);
                MessageBox.Show("contul a fost inchis");
                
            }
            catch
            {
                MessageBox.Show("contul nu a fost selectat ");
            }
        }
        private void DeschideCont_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = (Client)datagrid.SelectedItem;
                if(client==null)
                {
                    throw new Exception();
                }
                OpenAccount openAccount = new OpenAccount(client);
                openAccount.Show();
            }
            catch
            {
                MessageBox.Show("Clientul nu a fost selectat");
            }
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ContBancar contBancar = (ContBancar)contdatagrid.SelectedItem;
                if(contBancar==null)
                {
                    throw new Exception();
                }
                contBancar = access.GetTipCont(contBancar.IBAN);
                Transfer transfer = new Transfer(contBancar);
                transfer.Show();
            }
            catch
            {
                MessageBox.Show("Contul nu a fost selectat");
            }
        }

        private void Extras_Click(object sender, RoutedEventArgs e)
        {
           
           
            ContBancar cont;
            cont = (ContBancar)contdatagrid.SelectedItem;
            if (cont == null)
            {
                throw new Exception();
            }
            int items = contdatagrid.Items.Count;
            GenerarePDF generarePDF = new GenerarePDF(cont, items);
            generarePDF.Show();
           
           
           

            MessageBox.Show("Contul nu a fost selectat");
           
           

        }

        private void cresc_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = (Client)datagrid.SelectedItem;
                if(client== null || txtSold.Text==null)
                {
                    throw new Exception();
                }
                contdatagrid.ItemsSource = access.SearchCont((float)Convert.ToInt32(txtSold.Text), client.ID);
            }
            catch
            {
                MessageBox.Show("Clientul sau suma nu au fost selectate");
            }
        }

        private void desc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = (Client)datagrid.SelectedItem;
                if (client == null || txtSold.Text == null)
                {
                    throw new Exception();
                }
                contdatagrid.ItemsSource = access.SearchContdesc((float)Convert.ToInt32(txtSold.Text), client.ID);
            }
            catch
            {
                MessageBox.Show("Clientul sau suma nu au fost selectate");
            }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = (Client)datagrid.SelectedItem;
                if (client == null || txtSold.Text == null)
                {
                    throw new Exception();
                }
                contdatagrid.ItemsSource = access.SearchIBAN(txtIban.Text, client.ID);
            }
            catch
            {
                MessageBox.Show("Clientul sau suma nu au fost selectate");
            }
           
            
        }

        private void IBan_GotFocut(object sender, RoutedEventArgs e)
        {

            txtIban.Text = "";

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
