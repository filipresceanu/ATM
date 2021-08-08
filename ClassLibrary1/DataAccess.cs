using ATM;
using ClassLibrary1;
using Functii;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace Operati_BANCARE
{
    public class DataAccess
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
        public void insertClient(Client client)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Client(Nume,Prenume,Adresa,CNP) VALUES (@Nume,@Prenume,@Adresa,@CNP)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nume", client.Nume);
            cmd.Parameters.AddWithValue("@Prenume", client.Prenume);
            cmd.Parameters.AddWithValue("@Adresa", client.Adresa);
            cmd.Parameters.AddWithValue("@CNP", client.CNP);
            cmd.ExecuteNonQuery();
            con.Close();
        }
       
        public List<Client> GetClients()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            List<Client> clients = new List<Client>();
            string select = "Select * from Client";
            SqlCommand cmd = new SqlCommand(select, con);
            using (con)
            {

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ID = reader.GetInt32(0);
                    client.Nume = reader.GetString(1);
                    client.Prenume = reader.GetString(2);
                    client.Adresa = reader.GetString(3);
                    client.CNP = reader.GetString(4);
                    
                    clients.Add(client);
                }
                return clients;
            }

        }
        public ContBancar Login(string CNP, string PIN)
        {
            ContBancar contBancar = new ContBancar();
            con.Open();
            string query = "select * from ContBancar Inner Join Client" +
                " ON Client.ID = ContBancar.ID_Client " +
                "where ContBancar.PIN = @PIN AND Client.CNP = @CNP";


            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@CNP", CNP);
                sqlCommand.Parameters.AddWithValue("@PIN", PIN);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    contBancar.ID = sqlDataReader.GetInt32(0);
                    contBancar.PIN = sqlDataReader.GetInt32(1);
                    contBancar.TotalSold = (float)sqlDataReader.GetDouble(2);
                    contBancar.IBAN = sqlDataReader.GetString(3);
                   

                }
                return contBancar;
            }
        }
        public List<ContBancar>GetContBancars(int ID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            List<ContBancar> accounts = new List<ContBancar>();
            string select = "Select * from ContBancar where ID_Client=@ID";
            SqlCommand cmd = new SqlCommand(select, con);
            using (con)
            {

                con.Open();

                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContBancar cont = new ContBancar();
                    cont.ID = reader.GetInt32(0);
                    cont.IBAN = reader.GetString(3);
                    cont.TotalSold = (float)reader.GetDouble(2);
                    cont.Moneda = reader.GetString(5);
                    accounts.Add(cont);
                }
                return accounts;
            }
        }

        public int numbersOfEntries()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            using (con)
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Client", con))
                {
                    Int32 count = (Int32)cmd.ExecuteScalar();
                    return count;
                }

            }
        }
        public void updateSold(float sold, int ID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            string updateSold = "update ContBancar set Sold=@Sold  " +
                "where ID=@ID";

            using (con)
            {
                con.Open();
                using (SqlCommand sqlCommand = new SqlCommand(updateSold, con))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@ID", ID);

                    sqlCommand.Parameters.AddWithValue("@Sold", sold);
                    sqlCommand.ExecuteReader();
                    
                }
            }

        }
        public void DeleteAccount(int ID)
        {
            
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int); pID.Value = ID;
                string deleteQuery = "delete from ContBancar where ID=@ID";
                using (con)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))

                    {
                        cmd.Parameters.Add(pID);
                        cmd.ExecuteNonQuery();

                    }
                }
                       
        }
        public void schimbPIN(int PIN, int ID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            string updatePIN = "update ContBancar set PIN=@PIN " +
                "where ID=@ID";

            using (con)
            {
                con.Open();
                using (SqlCommand sqlCommand = new SqlCommand(updatePIN, con))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@ID", ID);

                    sqlCommand.Parameters.AddWithValue("@PIN", PIN);
                    sqlCommand.ExecuteReader();

                }
            }
        }
        public void Add_ContBancar(Client client,int ID,ContBancar cont)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(" insert ContBancar (ID_TipBancar,ID_Client,PIN," +
                "IBAN,Moneda,Data,Sold) values (@ID_TipBancar,@Id_Client,@PIN,@IBAN,@Moneda,11/11/11,@Sold)", con);
            cmd.CommandType = CommandType.Text;
           cmd.Parameters.AddWithValue("@ID_TipBancar", ID);
           cmd.Parameters.AddWithValue("@Id_Client",client.ID);
            cmd.Parameters.AddWithValue("@PIN", cont.generarePIN());
           cmd.Parameters.AddWithValue("@IBAN", cont.RandomIBAN());
            cmd.Parameters.AddWithValue("@Sold", cont.TotalSold);
            cmd.Parameters.AddWithValue("@Moneda",cont.Moneda);
            
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public ContBancar GetTipCont(string iBAN)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            ContBancar cont=new ContBancar();
            string select = "Select * from ContBancar inner join TipCont ON TipCont.ID=ContBancar.ID_TipBancar where ContBancar.IBAN=@IBAN";
            SqlCommand cmd = new SqlCommand(select, con);
            using (con)
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IBAN", iBAN);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cont.ID = reader.GetInt32(0);
                    cont.PIN = reader.GetInt32(1);
                    cont.TotalSold = (float)reader.GetDouble(2);
                    cont.IBAN = reader.GetString(3);
                    cont.Moneda = reader.GetString(5);
                    cont.tipContBancar.ID = reader.GetInt32(8);
                    cont.tipContBancar.Nume = reader.GetString(9);
                    cont.tipContBancar.ProcentDepunere = (float)reader.GetDouble(10);
                    cont.tipContBancar.ProcentRetragere = (float)reader.GetDouble(11);
                    cont.tipContBancar.SumaFixaDepunere= (float)reader.GetDouble(12);
                    cont.tipContBancar.SumaFixaRetragere = (float)reader.GetDouble(13);
                   
                }
                return cont;
            }

        }
        public void insertTranzactii(Tranzacti tranzacti )
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tranzactie(ID_ContBancar,Operatia,Data,Suma,ID_ContBancarDestinatie) VALUES (@ID,@Operatia,@Data,@Suma,@ID_ContBancarDestinatie)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", tranzacti.cont.ID);
            cmd.Parameters.AddWithValue("@Operatia", tranzacti.operatia);
            cmd.Parameters.AddWithValue("@Data", tranzacti.dateTime);
            cmd.Parameters.AddWithValue("@Suma", tranzacti.Sold);
            cmd.Parameters.AddWithValue("@ID_ContBancarDestinatie",tranzacti.contDestinatie);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Tranzacti> GetTranzactis(int ID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tranzactie inner join ContBancar on ContBancar.ID=Tranzactie.ID_ContBancar where ContBancar.ID=@ID ", con);
            List<Tranzacti> tranzactis = new List<Tranzacti>();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tranzacti tranzacti = new Tranzacti();
                
                tranzacti.operatia = reader.GetString(2);
                tranzacti.dateTime = reader.GetDateTime(3);
                tranzacti.Sold = (float)reader.GetDouble(4);
                tranzacti.contDestinatie = reader["ID_ContBancarDestinatie"] == System.DBNull.Value ? default(int) : (int)reader["ID_ContBancarDestinatie"];


                tranzactis.Add(tranzacti);
            }
            return tranzactis;
           
        }
       
        public List<ContBancar>SearchCont(float number,int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            List<ContBancar> accounts = new List<ContBancar>();
            string select = "select  * from ContBancar where Sold>@Sold and ID_Client=@Id order by Sold ASC";
            SqlCommand cmd = new SqlCommand(select, con);
            using (con)
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sold",number);
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContBancar cont = new ContBancar();
                    cont.ID = reader.GetInt32(0);
                    cont.IBAN = reader.GetString(3);
                    cont.TotalSold = (float)reader.GetDouble(2);
                    cont.Moneda = reader.GetString(5);
                    accounts.Add(cont);
                }
                return accounts;
            }
        }

        public List<ContBancar> SearchContdesc(float number, int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            List<ContBancar> accounts = new List<ContBancar>();
            string select = "select  * from ContBancar where Sold>@Sold and ID_Client=@Id order by Sold DESC";
            SqlCommand cmd = new SqlCommand(select, con);
            using (con)
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sold", number);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContBancar cont = new ContBancar();
                    cont.ID = reader.GetInt32(0);
                    cont.IBAN = reader.GetString(3);
                    cont.TotalSold = (float)reader.GetDouble(2);
                    cont.Moneda = reader.GetString(5);
                    accounts.Add(cont);
                }
                return accounts;
            }
        }

        public List<ContBancar> SearchIBAN(string iban, int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJPRE84;Initial Catalog=ATM;Integrated Security=True");
            List<ContBancar> accounts = new List<ContBancar>();
            string select = "select  * from ContBancar where IBAN like @Iban and ID_Client=@id";
            SqlCommand cmd = new SqlCommand(select, con);
            using (con)
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Iban","%"+iban+"%");
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContBancar cont = new ContBancar();
                    cont.ID = reader.GetInt32(0);
                    cont.IBAN = reader.GetString(3);
                    cont.TotalSold = (float)reader.GetDouble(2);
                    cont.Moneda = reader.GetString(5);
                    accounts.Add(cont);
                }
                return accounts;
            }
        }
    }
}

    
