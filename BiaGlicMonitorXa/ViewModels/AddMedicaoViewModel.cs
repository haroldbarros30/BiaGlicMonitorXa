using BiaGlicMonitorXa.Services;
using Xamarin.Forms;

namespace BiaGlicMonitorXa.ViewModels
{
    public class AddMedicaoViewModel:BaseViewModel
    {
        /// <summary>
        /// The API service.
        /// </summary>
		private readonly IApiService _ApiService;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="ApiService">API service.</param>
        public AddMedicaoViewModel(IApiService ApiService)
		{
			_ApiService = ApiService;
			GravarCommand = new Command(ExecuteGravarCommand, CanExecuteGravarCommand);
            Title = "Adicionar Medição";
		}


        private string _Valor;

		/// <summary>
		/// Valor medido informado pelo usuario
		/// </summary>
		public string Valor
		{
			get { return _Valor; }
			set
			{
				SetProperty(ref _Valor, value);
				GravarCommand.ChangeCanExecute();
			}
		}

        /// <summary>
        /// Command para gravar o valor informado
        /// </summary>
        /// <value>The gravar command.</value>
		public Command GravarCommand { get; }

		/// <summary>
		/// Verifica se pode gravar
		/// </summary>
		/// <returns><c>true</c>, if execute gravar command was caned, <c>false</c> otherwise.</returns>
		private bool CanExecuteGravarCommand()
		{
			double ValorConvertido = 0;
			//tenta converter o valor
			double.TryParse(this.Valor, out ValorConvertido);

			return (ValorConvertido > 0);
		}

        /// <summary>
        /// Execucao do comando gravar
        /// </summary>
		private void ExecuteGravarCommand()
		{

			double ValorConvertido = 0;
			//tenta converter o valor
			double.TryParse(this.Valor, out ValorConvertido);

            //Adiciona a medicao ao usuario logado
            _ApiService.AddMedicao(new Models.Medicao(ValorConvertido));
		}

      

    }
}
