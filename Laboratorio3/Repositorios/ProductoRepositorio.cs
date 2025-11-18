using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoDb;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Laboratorio3.Models;

namespace Laboratorio3.Repositorios
{
    public class ProductoRepositorio
    {
        private readonly string _conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        public void Insertar(Producto p)
        {
            using (var con = new SqlConnection(_conexion))
            {
                con.Insert(p);
            }
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            using (var con = new SqlConnection(_conexion))
            {
                return con.QueryAll<Producto>().ToList();
            }
        }

        public Producto ObtenerPorId(int id)
        {
            using (var con = new SqlConnection(_conexion))
            {
                return con.Query<Producto>(id).FirstOrDefault();
            }
        }

        public void Actualizar(Producto p)
        {
            using (var con = new SqlConnection(_conexion))
            {
                con.Update(p);
            }
        }
    }
}
