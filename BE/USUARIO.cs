using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class USUARIO
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private int intentosFallidos;

		public int IntentosFallidos
		{
			get { return intentosFallidos; }
			set { intentosFallidos = value; }
		}


		private int bloqueado;

		public int Bloqueado
		{
			get { return bloqueado; }
			set { bloqueado = value; }
		}




	}
}
