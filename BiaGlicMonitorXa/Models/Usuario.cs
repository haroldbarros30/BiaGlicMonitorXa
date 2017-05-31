using System;
using System.Collections.Generic;

namespace BiaGlicMonitorXa.Models
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public String Id;
        public String Nome;
		public String Email;
		public String Telefone;
		public List<Medicao> Medicoes;

    }
}
