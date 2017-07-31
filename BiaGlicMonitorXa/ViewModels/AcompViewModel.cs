using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using BiaGlicMonitorXa.Services;
using Xamarin.Forms;

namespace BiaGlicMonitorXa.ViewModels
{
    public class AcompViewModel:BaseViewModel
    {
		private readonly IApiService _ApiService;

        public AcompViewModel(IApiService ApiService)
        {
			_ApiService = ApiService;
            usuarios = new ObservableCollection<Usuario>();
            ItemSelectedCommand = new Command(ExecuteItemSelectedCommand);
			Title = "Acompanhamento";
           
        }

        private async void ExecuteItemSelectedCommand()
        {
			await PushAsync<AcompDetalheViewModel>(usuarioselecionado);
        }

        public Command ItemSelectedCommand { get; }

        public Usuario usuarioselecionado { get; set; }

		public ObservableCollection<Usuario> usuarios { get; }



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
                MsgInfo = "Carregando...";


                var oUsuarios = await _ApiService.GetUsuariosAsync();

                if (oUsuarios != null)
                {
                    usuarios.Clear();
                    foreach (var usuario in oUsuarios)
                    {

                        //pega as medicoes do usuario
                        usuario.Medicoes = await _ApiService.GetMedicaoAsync(usuario.Id);

                        usuarios.Add(usuario);
                    }

                    OnPropertyChanged(nameof(usuarios));
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
