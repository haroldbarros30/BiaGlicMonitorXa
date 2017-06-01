using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using BiaGlicMonitorXa.Services;

namespace BiaGlicMonitorXa.ViewModels
{
    public class AcompDetalheViewModel:BaseViewModel
    {
        private readonly IApiService _ApiService;

        public AcompDetalheViewModel(IApiService ApiService,Usuario usuario)
        {
            _ApiService = ApiService;
            medicoes = new ObservableCollection<Medicao>();
            _usuario = usuario;
            
            Title = "Histórico";

        }

        public ObservableCollection<Medicao> medicoes { get; }


        private Usuario _usuario;

		/// <summary>
		/// Nome do usuario
		/// </summary>
		public String Nome
		{
            get { return _usuario.Nome; }
		}


        /// <summary>
        /// Executado no carregamento da BasePage
        /// </summary>
        /// <returns>The async.</returns>
		public override async Task LoadAsync()
        {
            var oMedicoes = await _ApiService.GetMedicaoAsync(_usuario.Id);

            if (oMedicoes != null)
            {
                medicoes.Clear();
                foreach (var medicao in oMedicoes)
                {
                    medicoes.Add(medicao);
                }

                OnPropertyChanged(nameof(medicoes));
            }
		}

    }
}
