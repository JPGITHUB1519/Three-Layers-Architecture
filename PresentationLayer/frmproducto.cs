﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntitiesLayer;
using BusinessLogicLayer;

namespace PresentationLayer
{
    public partial class frmproducto : Form
    {
        public frmproducto()
        {
            InitializeComponent();
        }

        // creating necessary objects
        private EProducto producto = new EProducto();
        private BProducto bus_producto = new BProducto();
        private DataSet ds = new DataSet();

        public void llenar_grid()
        {
            ds= bus_producto.select();
            this.dataGridView1.DataSource = ds.Tables[0] ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rpta = "";
            producto.Id = Convert.ToInt32(this.txtid.Text.Trim());
            producto.Descripcion = this.txtdescripcion.Text.Trim();
            producto.Marca = this.txtmarca.Text.Trim();
            producto.Precio = Convert.ToDecimal(this.txtprecio.Text.Trim());

            rpta =  bus_producto.insert(producto);
            MessageBox.Show(rpta);
            llenar_grid();
        }

        private void frmproducto_Load(object sender, EventArgs e)
        {
            llenar_grid();
        }
    }
}
