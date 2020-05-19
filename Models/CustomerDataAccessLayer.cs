using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OltcoApp.Models
{
    public class CustomerDataAccessLayer
    {
        string connectionString = "Server=tcp:oltcotest1.database.windows.net,1433;Initial Catalog=OltcoTest1;Persist Security Info=False;User ID=emmagreening;Password=Muldermoo1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // adding Installation Details
        //To View all customer and installation details    
        public IEnumerable<Customer> GetAllCustomers() //(already added installation table to procedure)
        {
            List<Customer> lstcustomer = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer = new Customer();

                    customer.ID = Convert.ToInt32(rdr["customer_id"]);
                    customer.customer_name = rdr["customer_name"].ToString();
                    customer.customer_address = rdr["customer_address"].ToString();
                    customer.phone_number = rdr["phone_number"].ToString();
                    customer.postcode = rdr["postcode"].ToString();
                    customer.email = rdr["email"].ToString();

                    lstcustomer.Add(customer);
                }
                con.Close();
            }
            return lstcustomer;
        }

        //To Add new customer record    
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customer_name", customer.customer_name);
                cmd.Parameters.AddWithValue("@customer_address", customer.customer_address);
                cmd.Parameters.AddWithValue("@phone_number", customer.phone_number);
                cmd.Parameters.AddWithValue("@postcode", customer.postcode);
                cmd.Parameters.AddWithValue("@email", customer.email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee  
        public void UpdateCustomer(Customer customer)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@customer_id", customer.ID);
            cmd.Parameters.AddWithValue("@customer_name", customer.customer_name);
            cmd.Parameters.AddWithValue("@customer_address", customer.customer_address);
            cmd.Parameters.AddWithValue("@phone_number", customer.phone_number);
            cmd.Parameters.AddWithValue("@postcode", customer.postcode);
            cmd.Parameters.AddWithValue("@email", customer.email);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Get the details of a particular customer 
        public Customer GetCustomerData(int? id)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM customer_details WHERE customer_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    customer.ID = Convert.ToInt32(rdr["customer_id"]);
                    customer.customer_name = rdr["customer_name"].ToString();
                    customer.customer_address = rdr["customer_address"].ToString();
                    customer.phone_number = rdr["phone_number"].ToString();
                    customer.postcode = rdr["postcode"].ToString();
                    customer.email = rdr["email"].ToString();

                }
            }
            return customer;
        }

        //To Delete the record on a particular customer  
        public void DeleteCustomer(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customer_id", id);
                //cmd.Parameters.AddWithValue("@installation_id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
