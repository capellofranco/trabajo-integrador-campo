using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ServidorSql
    {
        public static string Actual { get; private set; }

        public static string Detectar()
        {
            if (Actual != null) return Actual;

            var candidatos = new List<string>();
            foreach (var vista in new[] { RegistryView.Registry64, RegistryView.Registry32 })
            {
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, vista))
                using (var key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
                {
                    if (key == null) continue;
                    foreach (var nombre in key.GetValueNames())
                    {
                        string srv = nombre == "MSSQLSERVER" ? "." : @".\" + nombre;
                        if (!candidatos.Contains(srv)) candidatos.Add(srv);
                    }
                }
            }
            foreach (var c in new[] { @".\SQLEXPRESS", ".", @"(localdb)\MSSQLLocalDB" })
                if (!candidatos.Contains(c)) candidatos.Add(c);

            foreach (var c in candidatos)
            {
                try
                {
                    using (var cn = new SqlConnection(
                        $"Data Source={c};Initial Catalog=master;Integrated Security=True;Connect Timeout=3"))
                    {
                        cn.Open();
                        Actual = c;
                        return c;
                    }
                }
                catch { }
            }
            throw new Exception("No se encontró ninguna instancia de SQL Server en esta PC.");
        }
    }
}
