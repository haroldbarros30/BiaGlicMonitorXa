using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using BiaGlicMonitorXa.Services;
using Xamarin.Forms;

namespace BiaGlicMonitorXa.ViewModels
{
	public class MenuPrincipalViewModel : BaseViewModel
	{
		private readonly IApiService _ApiService;
		
		public Command AcompDetalheCommand { get; }

		public Command AcompCommand { get; }

        public Command AddMedicaoCommand { get; }

        public Command CadastroCommand { get; }


		public MenuPrincipalViewModel(IApiService pApiService)
		{
			_ApiService = pApiService;
			AcompDetalheCommand = new Command(ExecuteAcompDetalheCommand);
            AcompCommand = new Command(ExecuteAcompCommand);
            AddMedicaoCommand = new Command(ExecuteAddMedicaoCommand);
			CadastroCommand = new Command(ExecuteCadastroCommand);
            Title = "Bia Glic Monitor";
			
		}

		private async void ExecuteAcompDetalheCommand()
		{
			if (!VerificaUsuarioLogado())
				return;
            
            await PushAsync<AcompDetalheViewModel>(_ApiService.GetUsuarioLogado());
		}

		private async void ExecuteAddMedicaoCommand()
		{
			if (!VerificaUsuarioLogado())
				return;
            
            await PushAsync<AddMedicaoViewModel>();
		}

		private async void ExecuteAcompCommand()
		{
			if (!VerificaUsuarioLogado())
				return;
            
            await PushAsync<AcompViewModel>();
		}

		private async void ExecuteCadastroCommand()
		{



			await PushAsync<CadastroViewModel>();
		}


		public override async Task LoadAsync()
		{
            VerificaUsuarioLogado();
		}

        /// <summary>
        /// Se o usuario nao estiver logado o sistema chama a tela de cadastro/login
        /// </summary>
        /// <returns><c>true</c>, if usuario logado was verificaed, <c>false</c> otherwise.</returns>
        private bool VerificaUsuarioLogado()
        {
            if (!Settings.IsLoggedIn)
                ExecuteCadastroCommand();

            return Settings.IsLoggedIn;
        }

		

		
	}
}
