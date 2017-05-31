using BiaGlicMonitorXa.Services;
using BiaGlicMonitorXa.ViewModels;
using Xamarin.Forms;

namespace BiaGlicMonitorXa
{
    public partial class MenuPrincipalPage : ContentPage
    {
        private MenuPrincipalViewModel ViewModel => BindingContext as MenuPrincipalViewModel;

        public MenuPrincipalPage()
        {
            InitializeComponent();
			var ApiService = DependencyService.Get<IApiService>();
			BindingContext = new MenuPrincipalViewModel(ApiService);
        }
    }
}
