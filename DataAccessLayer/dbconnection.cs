using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class dbconnection
    {
        public string connection_string = DataAccessLayer.Properties.Settings.Default.cn;

        public static DataSet ejecuta(string query, string[] parametros, string[] valores)
        {
            
            DataSet ds = new DataSet();
            string rpta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = DataAccessLayer.Properties.Settings.Default.cn;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;

                // addign parameters values
                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametros[i], valores[i]);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
            
        }
    }

}
