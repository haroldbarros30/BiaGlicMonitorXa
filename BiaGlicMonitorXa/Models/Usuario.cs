using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Linq;

namespace BiaGlicMonitorXa.Models
{
    /// <summary>
    /// Classe responsavel por guardar os dados do usuario
    /// </summary>
    public class Usuario
    {

		public Usuario()
		{
			this._id = "";
			this._nome = "";
			this._email = "";
			this._telefone = "";

		}

		
        private string _id;
        private string _nome;
        private string _email;
        private string _telefone;

		[JsonProperty(PropertyName = "id")]
        public String Id { get {return _id; } set{ _id = value; } }

		[JsonProperty(PropertyName = "nome")]
		public String Nome { get { return _nome; } set { _nome = value; } }

		[JsonProperty(PropertyName = "email")]
		public String Email { get { return _email; } set { _email = value; } }

		[JsonProperty(PropertyName = "telefone")]
		public String Telefone { get { return _telefone; } set { _telefone = value; } }

		[JsonIgnore]
		public List<Medicao> Medicoes { get; set; }

        [JsonIgnore]
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

		[Version]
		public string Version { get; set; }

		
    }
}
