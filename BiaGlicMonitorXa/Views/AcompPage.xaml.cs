using System;
using System.Collections.Generic;
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
    }
}
