using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OltcoApp.Models
{
    public class InstallationDataAccessLayer
    {
    
        string connectionString = "Server=tcp:oltcotest1.database.windows.net,1433;Initial Catalog = OltcoTest1; Persist Security Info=False;User ID = emmagreening; Password=Muldermoo1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

            
         // adding Installation Details
        //To View all installation details    
        public IEnumerable<Installation> GetAllInstallations()
        {
            List<Installation> lstinstallation = new List<Installation>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllInstallations", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Installation installation = new Installation();
                   
                    // adding Installation Details
                    installation.installation_id = Convert.ToInt32(rdr["installation_id"]);
                    installation.installation_cost = Convert.ToInt32(rdr["installation_cost"]);
                    installation.installation_extras = Convert.ToInt32(rdr["installation_extras"]);
                    installation.installation_size = Convert.ToInt32(rdr["installation_size"]);
                    installation.stone_reading_humidity = Convert.ToInt32(rdr["stone_reading_humidity"]);
                    installation.stone_reading_temperature = Convert.ToInt32(rdr["stone_reading_temperature"]);
                 //   installation.customer_id = rdr["customer_id"];ToString();

                    lstinstallation.Add(installation);
                }
                con.Close();
            }
            return lstinstallation;
        }

        //To Add new installation record    
        public void AddInstallation(Installation installation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddInstallation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@installation_cost", installation.installation_cost);
                cmd.Parameters.AddWithValue("@installation_extras", installation.installation_extras);
                cmd.Parameters.AddWithValue("@installation_size", installation.installation_size);
                cmd.Parameters.AddWithValue("@stone_reading_humidity", installation.stone_reading_humidity);
                cmd.Parameters.AddWithValue("@stone_reading_temperature", installation.stone_reading_temperature);
                //cmd.Parameters.AddWithValue("@customer_id", installation.customer_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee  
        public void UpdateInstallation(Installation installation)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spUpdateInstallation", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@installation_id", installation.installation_id);
            cmd.Parameters.AddWithValue("@installation_cost", installation.installation_cost);
            cmd.Parameters.AddWithValue("@installation_extras", installation.installation_extras);
            cmd.Parameters.AddWithValue("@installation_size", installation.installation_size);
            cmd.Parameters.AddWithValue("@stone_reading_humidity", installation.stone_reading_humidity);
            cmd.Parameters.AddWithValue("@stone_reading_temperature", installation.stone_reading_temperature);
           // cmd.Parameters.AddWithValue("@customer_id", installation.customer_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Get the details of a particular Installation 
        public Installation GetInstallationData(int? installation_id)
        {
            if (installation_id is null)
            {
                throw new ArgumentNullException(nameof(installation_id));
            }

            Installation installation = new Installation();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Installation_details WHERE installation_id= " + installation_id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    installation.installation_id = Convert.ToInt32(rdr["installation_id"]);
                    installation.installation_cost = Convert.ToInt32(rdr["installation_cost"]);
                    installation.installation_extras = Convert.ToInt32(rdr["installation_extras"]);
                    installation.installation_size = Convert.ToInt32(rdr["installation_size"]);
                    installation.stone_reading_humidity = Convert.ToInt32(rdr["stone_reading_humidity"]);
                    installation.stone_reading_temperature = Convert.ToInt32(rdr["stone_reading_temperature"]);
                  //  installation.customer_id = Convert.ToInt32(rdr["customer_id"]);
                }
            }
            return installation;
        }

        //To Delete the record on a particular installation  
        public void DeleteInstallation(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteInstallation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@installation_id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
