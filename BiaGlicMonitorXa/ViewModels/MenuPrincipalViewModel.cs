using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        public Command ConfigCommand { get; }

		public MenuPrincipalViewModel(IApiService pApiService)
		{
			_ApiService = pApiService;
			AcompDetalheCommand = new Command(ExecuteAcompDetalheCommand);
            AcompCommand = new Command(ExecuteAcompCommand);
            AddMedicaoCommand = new Command(ExecuteAddMedicaoCommand);
			CadastroCommand = new Command(ExecuteCadastroCommand);
			ConfigCommand = new Command(ExecuteConfigCommand);
			
		}

		private async void ExecuteAcompDetalheCommand()
		{
			//await PushAsync<AcompDetalheViewModel>();
		}

		private async void ExecuteAddMedicaoCommand()
		{
			//await PushAsync<AddMedicaoViewModel>();
		}

		private async void ExecuteAcompCommand()
		{
			//await PushAsync<AcompViewModel>();
		}

		private async void ExecuteCadastroCommand()
		{
			//await PushAsync<CadastroViewModel>();
		}

        private async void ExecuteConfigCommand()
		{
			//await PushAsync<ConfigViewModel>();
		}

		
	}
}
