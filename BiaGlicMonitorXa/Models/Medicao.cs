using System;
namespace BiaGlicMonitorXa.Models
{

    /// <summary>
    /// Classe responsavel por guardar os dados de medicao do usuario
    /// </summary>
    public class Medicao
    {
        
        public Medicao()
        {
        }

        /// <summary>
        /// Construtor, que define a data e hora da medicao passando apenas o valor da mesma
        /// </summary>
        /// <param name="pValor">P valor.</param>
		public Medicao(double pValor)
		{

            //busca a data atual
            DateTime DataAtual = DateTime.Now;

            this.Id = DataAtual.ToString("yyyyMMddHHmmss");
			this.Data = DataAtual.ToString("yyyyMMdd");
			this.Hora = DataAtual.ToString("HH:mm:ss");
			this.Valor = pValor;
		}


		public Medicao(String pId, String pData, String pHora, double pValor)
		{
			this.Id = pId;
			this.Data = pData;
			this.Hora = pHora;
			this.Valor = pValor;
		}

        public String Id { get; set; }
		public String Data{ get; set; }
		public String Hora{ get; set; }
		public double Valor{ get; set; }


        /// <summary>
        /// Propriedade que retorna a data e a hora concatenada para ser exibida na listView
        /// </summary>
        /// <value>The data hora.</value>
        public String DataHora
        {
            get { return Data+" "+Hora; }
        }
       
    }
}
