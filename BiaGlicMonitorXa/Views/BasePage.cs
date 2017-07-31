using System.ComponentModel;
using BiaGlicMonitorXa.ViewModels;
using Xamarin.Forms;

namespace BiaGlicMonitorXa
{
	/// <summary>
	/// Classe base para as views a ser herdada por todas as view
	/// </summary>
	public abstract class BasePage : ContentPage
	{
		private BaseViewModel ViewModel => BindingContext as BaseViewModel;

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (ViewModel == null) return;
			Title = ViewModel.Title;
			ViewModel.PropertyChanged += TitlePropertyChanged;
			await ViewModel.LoadAsync();
		}

		private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != nameof(ViewModel.Title)) return;

			Title = ViewModel.Title;
		}
	}
}