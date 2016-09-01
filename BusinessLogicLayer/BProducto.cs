using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using DataAccessLayer;

/* Capa Negocio en esta capa hago las validaciones y recojo los datos de presentacion
 * y se los envio a la capa datos y viceversa */

namespace BusinessLogicLayer
{
    public class BProducto
    {
        private DProducto data_producto = new DProducto();
        private readonly StringBuilder strbuild = new StringBuilder();

        public string insert(EProducto producto)
        {
            string rpta = "";
            // si los datos son incorrectos
            if (validar_producto(producto))
            {
                rpta = data_producto.insert(producto); 
            }
            else 
            {
                rpta = "Error Validacion";
            }

            return rpta;
        }

        private bool validar_producto(EProducto producto)
        {
            if(producto.Id <= 0)
            {
                strbuild.Append("El campo Id es obligatorio");
            }
            if (string.IsNullOrEmpty(producto.Descripcion))
            {
                strbuild.Append("El campo Descripción es obligatorio");
            }
            if (string.IsNullOrEmpty(producto.Marca))
            {
                strbuild.Append("El campo Marca es obligatorio");
            }
            if (producto.Precio <= 0)
            {
                strbuild.Append("El campo Precio es obligatorio");
            }
            return strbuild.Length == 0;
        }
    }
}
