using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class EProducto
    {
        private int _id;
        private string _descripcion;
        private string _marca;
        private decimal _precio;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }


    }
}
