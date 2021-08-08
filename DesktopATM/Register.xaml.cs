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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        DataAccess access = new DataAccess();
        public Register()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client cliet = new Client();
                cliet.Nume = txtNume.Text;
                cliet.Prenume = txtPrenume.Text;
                cliet.CNP = txtCNP.Text;
                cliet.Adresa = txtAdresa.Text;
               
                access.insertClient(cliet);
                MessageBox.Show("Success");


            }
            catch
            {
                MessageBox.Show("Datele introduse nu sunt complete");
            }
        }
    }
}
