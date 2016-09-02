using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DProducto
    {
        public string insert(EProducto producto)
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

        public string insert_with_ejecuta(EProducto producto)
        {
            string query = string.Format("exec spinsert_producto {0}, '{1}', '{2}', {3}", producto.Id, producto.Descripcion, producto.Marca, producto.Precio);

            if (dbconnection.ejecuta(query) != null)
            {
                return "Exito";
            }

            return "Error";

        }

        public DataSet mostrar_with_ejecuta()
        {
            DataSet ds = new DataSet();
            string query = "exec spselect_producto";
            ds = dbconnection.ejecuta(query);
            return ds;
        }
        // best
        public string insert_with_execute(EProducto producto)
        {
            DataSet ds = new DataSet();
            string rpta = "";
            // query to execute
            string cmd = "spinsert_producto";
            try
            {
                // creating dictionary with the params of the query
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", producto.Id);
                parameters.Add("@descripcion", producto.Descripcion);
                parameters.Add("@marca", producto.Marca);
                parameters.Add("@precio", producto.Precio);
                ds = dbconnection.execute_query(cmd, parameters);

                rpta = "EXITO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
 
        }

        public DataSet select_with_execute()
        {
            DataSet ds = new DataSet();
            string rpta = "";
            string cmd = "spselect_producto";

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                ds = dbconnection.execute_query(cmd, parameters);
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }

    }
}
