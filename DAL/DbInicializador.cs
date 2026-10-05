using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public static class DbInicializador
    {
        public static void AsegurarBaseDeDatos(string servidor, string nombreBD)
        {
            string csMaster = $"Data Source={servidor};Initial Catalog=master;Integrated Security=True";
            string cs = $"Data Source={servidor};Initial Catalog={nombreBD};Integrated Security=True";

            // 1. Crear la base si no existe
            using (var cn = new SqlConnection(csMaster))
            {
                cn.Open();
                using (var cmd = new SqlCommand(
                    $"IF DB_ID('{nombreBD}') IS NULL CREATE DATABASE [{nombreBD}];", cn))
                    cmd.ExecuteNonQuery();
            }

            // 2. Si ya tiene tablas, está inicializada: no hacer nada
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM sys.tables", cn))
                    if ((int)cmd.ExecuteScalar() > 0) return;
            }

            // 3. Ejecutar el script; si falla, borrar la base vacía
            try
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "crear_bd.sql");
                if (!File.Exists(ruta))
                    throw new FileNotFoundException("No se encontró el script de la base de datos.", ruta);

                string script = File.ReadAllText(ruta);
                var lotes = Regex.Split(script, @"^\s*GO\s*$",
                    RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    foreach (var lote in lotes)
                    {
                        if (string.IsNullOrWhiteSpace(lote)) continue;
                        using (var cmd = new SqlCommand(lote, cn))
                        {
                            cmd.CommandTimeout = 120;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            {
                SqlConnection.ClearAllPools();
                using (var cn = new SqlConnection(csMaster))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(
                        $"ALTER DATABASE [{nombreBD}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{nombreBD}];", cn))
                        cmd.ExecuteNonQuery();
                }
                throw; // para que Program.cs muestre el error real
            }
        }
    }
}
