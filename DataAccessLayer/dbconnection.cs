using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class dbconnection
    {
        public string connection_string = DataAccessLayer.Properties.Settings.Default.cn;
        /*
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
       */

        public static DataSet ejecuta(string query)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataAccessLayer.Properties.Settings.Default.cn;
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ds;

        }
        public string ejecuta_nuevo(EProducto producto, string query, SqlParameter[] parameters)
        {
            string rpta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = DataAccessLayer.Properties.Settings.Default.cn;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spinsert_producto";
                cmd.CommandType = CommandType.StoredProcedure;

                // addign parameters values
                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@marca", producto.Marca);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    rpta = "Exito";

                }
                else
                {
                    rpta = "Error";
                }

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return rpta;
        }

        /* this method take string and a dictionary[parameter_name, values] and return
          a dataset with the result of the query */
        public static DataSet execute_query(string query, Dictionary<string, object> parameters)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataAccessLayer.Properties.Settings.Default.cn;
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
   
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                if (parameters != null)
                {
                    // adding parameters to the commands
                    foreach (KeyValuePair<string, object> kvp in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ds;
        }

    }

}
