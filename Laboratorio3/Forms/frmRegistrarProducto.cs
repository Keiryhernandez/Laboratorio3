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
    public partial class frmRegistrarProducto : Form
    {
        ProductoRepositorio repo = new ProductoRepositorio();
        public frmRegistrarProducto()
        {
            InitializeComponent();
        }

        private void frmRegistrarProducto_Load(object sender, EventArgs e)
        {

            Limpiar();
            CargarDatos();

        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtCategoria.Clear();
            txtPrecioUnitario.Clear();
            txtCantidad.Clear();
            txtStockMinimo.Clear();
        }
        private void CargarDatos()
        {
            dgvRegistro.DataSource = repo.ObtenerTodos();

            foreach (DataGridViewRow fila in dgvRegistro.Rows)
            {
                int cant = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                int min = Convert.ToInt32(fila.Cells["StockMinimo"].Value);

                if (cant < min)
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                Nombre = txtNombre.Text,
                Codigo = txtCodigo.Text,
                Categoria = txtCategoria.Text,
                PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text),
                Cantidad = Convert.ToInt32(txtCantidad.Text),
                StockMinimo = Convert.ToInt32(txtStockMinimo.Text)
            };

            repo.Insertar(p);
            CargarDatos();
            Limpiar();
        }

        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvRegistro.Rows[e.RowIndex].Cells["IdProducto"].Value);

                frmRegistrarProductoCmd frm = new frmRegistrarProductoCmd(id);
                frm.ShowDialog();
                CargarDatos();
            }
        }
    }
}
