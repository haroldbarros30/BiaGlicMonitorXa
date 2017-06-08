using System;
using System.Collections.Generic;
using BiaGlicMonitorXa.Models;
using BiaGlicMonitorXa.ViewModels;
using Xamarin.Forms;

namespace BiaGlicMonitorXa
{
    public partial class AcompPage : BasePage
    {
		private AcompViewModel ViewModel => BindingContext as AcompViewModel;

        public AcompPage()
        {
            InitializeComponent();
        }



        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //Obs: devera ser verificado na maratona a maneira correta de usar esta opcao com command sem utilizar o codebehind
           


		    if (e.SelectedItem != null && e.SelectedItem is Usuario)
			{
                Usuario usuarioselecionado = (Usuario)e.SelectedItem;
                ViewModel.usuarioselecionado = usuarioselecionado;
                ViewModel.ItemSelectedCommand.Execute(null);
			}

           

		

        }
    }
}
