using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorio3.Repositorios;
using Laboratorio3.Utils;

namespace Laboratorio3.Forms
{
    public partial class frmLogin : Form
    {
        UsuarioRepositorio repo = new UsuarioRepositorio();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = Seguridad.HashSHA256(txtContraseña.Text);

            var user = repo.Login(usuario, contrasena);

            if (user != null)
            {
                frmRegistrarProducto frm = new frmRegistrarProducto();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
