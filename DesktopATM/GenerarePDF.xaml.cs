using ATM;
using ClassLibrary1;
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

namespace DesktopATM
{
    /// <summary>
    /// Interaction logic for GenerarePDF.xaml
    /// </summary>
    public partial class GenerarePDF : Window
    {
        DataAccess access = new DataAccess();
        Tranzacti tranzactii = new Tranzacti();
        WordGenerator word = new WordGenerator();
        private ContBancar _contBancar;
        private int _items;
        public GenerarePDF(ContBancar cont,int numbers)
        {
            InitializeComponent();
            this._contBancar = cont;
            //tranzactii =(Tranzacti)access.GetTranzactis((int)_contBancar.ID);
            datagrid.ItemsSource = access.GetTranzactis(_contBancar.ID);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Operatia",typeof(string));
            dataTable.Columns.Add("Sold",typeof(float));
            dataTable.Columns.Add("Destinatar",typeof(string));
            dataTable.Columns.Add("Date",typeof(DateTime));
           
                dataTable.Rows.Add(access.GetTranzactis(_contBancar.ID)[1].operatia,
                    access.GetTranzactis(_contBancar.ID)[1].Sold,access.GetContBancars((int)access.GetTranzactis(_contBancar.ID)[1].contDestinatie)[1].IBAN,
                    access.GetTranzactis(_contBancar.ID)[1].dateTime);
           
            datagrid.DataContext = dataTable.DefaultView;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
           
            Tranzacti tranzacti = (Tranzacti)datagrid.SelectedItem;
          
        }
    }
}
