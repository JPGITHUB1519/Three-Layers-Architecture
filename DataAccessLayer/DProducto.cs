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

    }
}
