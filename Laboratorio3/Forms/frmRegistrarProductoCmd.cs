using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorio3.Models;
using Laboratorio3.Repositorios;

namespace Laboratorio3.Forms
{
   
    public partial class frmRegistrarProductoCmd : Form
    {
        private int _idProducto;
        private readonly ProductoRepositorio repo = new ProductoRepositorio();
        public frmRegistrarProductoCmd()
        {
            InitializeComponent();
            
        }

        public frmRegistrarProductoCmd(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;
        }

        private void frmRegistrarProductoCmd_Load(object sender, EventArgs e)
        {
            var p = repo.ObtenerPorId(_idProducto);

            txtNombre.Text = p.Nombre;
            txtCodigo.Text = p.Codigo;
            txtCategoria.Text = p.Categoria;
            txtPrecioUnitario.Text = p.PrecioUnitario.ToString();
            txtCantidad.Text = p.Cantidad.ToString();
            txtStockMinimo.Text = p.StockMinimo.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                IdProducto = _idProducto,
                Nombre = txtNombre.Text,
                Codigo = txtCodigo.Text,
                Categoria = txtCategoria.Text,
                PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text),
                Cantidad = Convert.ToInt32(txtCantidad.Text),
                StockMinimo = Convert.ToInt32(txtStockMinimo.Text)
            };

            repo.Actualizar(p);
            MessageBox.Show("Actualizado correctamente");
            this.Close();
        }
    }


}
