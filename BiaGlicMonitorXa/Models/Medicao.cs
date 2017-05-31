using System;
namespace BiaGlicMonitorXa.Models
{
    public class Medicao
    {
        public Medicao()
        {
        }

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

		public String Id;
		public String Data;
		public String Hora;
		public double Valor;
    }
}
