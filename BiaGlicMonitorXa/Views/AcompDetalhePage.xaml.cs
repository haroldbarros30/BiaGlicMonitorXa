using System;
using System.Collections.Generic;
using BiaGlicMonitorXa.ViewModels;
using Xamarin.Forms;

namespace BiaGlicMonitorXa
{
    public partial class AcompDetalhePage: BasePage
    {

        private AcompDetalheViewModel ViewModel => BindingContext as AcompDetalheViewModel;

        public AcompDetalhePage()
        {
            InitializeComponent();
        }
    }
}
