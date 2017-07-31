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



        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                SetProperty(ref _IsBusy, value);
            }
        }



		string _MsgInfo;
		public string MsgInfo
		{
			get { return _MsgInfo; }
			set
			{
				SetProperty(ref _MsgInfo, value);
			}
		}


        /// <summary>
        /// Executado no carregamento da BasePage
        /// </summary>
        /// <returns>The async.</returns>
		public override async Task LoadAsync()
        {

			if (IsBusy)
				return;

            try
            {
                IsBusy = true;
                MsgInfo = "Carregando mediçoes...";
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

                MsgInfo = "";

            }
			catch (Exception ex)
			{
                MsgInfo = $"Erro:{ex.Message}";
			}
            finally
            {
                IsBusy = false;
            }

           
		}

    }
}
