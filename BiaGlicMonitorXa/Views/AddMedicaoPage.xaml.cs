using System;
using System.Collections.Generic;
using BiaGlicMonitorXa.ViewModels;
using Xamarin.Forms;

namespace BiaGlicMonitorXa
{
    public partial class AddMedicaoPage : ContentPage
    {
		private AddMedicaoViewModel ViewModel => BindingContext as AddMedicaoViewModel;

        public AddMedicaoPage()
        {
            InitializeComponent();
        }
    }
}
