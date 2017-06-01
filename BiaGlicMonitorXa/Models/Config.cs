using System;
namespace BiaGlicMonitorXa.Models
{
	/// <summary>
	/// Classe responsavel por guardar as configuracoes do sistema
	/// </summary>
	public class Config
    {
        
        public Config()
        {
            Lembrete = 60;
        }

        /// <summary>
        /// Tempo em minutos que devera ser utilizado para lembrar o usuario de fazer as medicoes, default 60 minutos
        /// </summary>
        public int Lembrete { get; set; }
    }
}
