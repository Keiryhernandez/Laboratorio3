using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio3.Models;
using RepoDb;
using System.Data.SqlClient;
using System.Linq;

namespace Laboratorio3.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly string _conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        public Usuario Login(string usuario, string contrasenaHash)
        {
            using (var con = new SqlConnection(_conexion))
            {
                return con.Query<Usuario>(u =>
                    u.UsuarioNombre == usuario &&
                    u.ContrasenaHash == contrasenaHash).FirstOrDefault();
            }
        }
    }
}
