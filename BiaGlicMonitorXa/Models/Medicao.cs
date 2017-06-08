using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace BiaGlicMonitorXa.Models
{

    /// <summary>
    /// Classe responsavel por guardar os dados de medicao do usuario
    /// </summary>
    public class Medicao
    {
        
        public Medicao()
        {
			this.UsuarioId = Settings.UserId;
        }

        /// <summary>
        /// Construtor, que define a data e hora da medicao passando apenas o valor da mesma
        /// </summary>
        /// <param name="pValor">P valor.</param>
		public Medicao(double pValor)
		{

            //busca a data atual
            DateTime DataAtual = DateTime.Now;

            this.UsuarioId = Settings.UserId;
            this.Id = DataAtual.ToString("yyyyMMddHHmmss");
			this.Data = DataAtual.ToString("yyyyMMdd");
			this.Hora = DataAtual.ToString("HH:mm:ss");
			this.Valor = pValor;
		}


		public Medicao(String pId, String pData, String pHora, double pValor)
		{
            this.UsuarioId = Settings.UserId;
			this.Id = pId;
			this.Data = pData;
			this.Hora = pHora;
			this.Valor = pValor;
		}


		[JsonProperty(PropertyName = "usuarioid")]
		public String UsuarioId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "data")]
		public String Data{ get; set; }

        [JsonProperty(PropertyName = "hora")]
		public String Hora{ get; set; }

        [JsonProperty(PropertyName = "valor")]
		public double Valor{ get; set; }


        /// <summary>
        /// Propriedade que retorna a data e a hora concatenada para ser exibida na listView
        /// </summary>
        /// <value>The data hora.</value>
        [JsonIgnore]
        public String DataHora
        {
            get { return Data+" "+Hora; }
        }


		[Version]
		public string Version { get; set; }
       
    }
}
