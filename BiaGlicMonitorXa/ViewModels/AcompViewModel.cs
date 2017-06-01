using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using BiaGlicMonitorXa.Services;

namespace BiaGlicMonitorXa.ViewModels
{
    public class AcompViewModel:BaseViewModel
    {
		private readonly IApiService _ApiService;

        public AcompViewModel(IApiService ApiService)
        {
			_ApiService = ApiService;
            usuarios = new ObservableCollection<Usuario>();
			Title = "Acompanhamento";
           
        }

		public ObservableCollection<Usuario> usuarios { get; }

		/// <summary>
		/// Executado no carregamento da BasePage
		/// </summary>
		/// <returns>The async.</returns>
		public override async Task LoadAsync()
		{
            var oUsuarios = await _ApiService.GetUsuariosAsync();

			if (oUsuarios != null)
			{
				usuarios.Clear();
				foreach (var usuario in oUsuarios)
				{
					usuarios.Add(usuario);
				}

                OnPropertyChanged(nameof(usuarios));
			}
			
		}
    }
}
