using System;
using System.Collections.Generic;

namespace BiaGlicMonitorXa.Models
{
    /// <summary>
    /// Classe responsavel por guardar os dados do usuario
    /// </summary>
    public class Usuario
    {
        public Usuario()
        {
        }


        public String Id {get;set;}
        public String Nome{ get; set; }
		public String Email { get; set; }
		public String Telefone { get; set; }
		public List<Medicao> Medicoes { get; set; }



        public Medicao UltimaMedicao
        {
            get{

				//se existe medicoes adicionadas
				if (Medicoes != null && Medicoes.Count > 0)
				{
					return Medicoes[Medicoes.Count - 1];
				}
				else
					return null;

            }
        }

		
    }
}
