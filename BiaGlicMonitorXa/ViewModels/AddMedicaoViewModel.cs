using BiaGlicMonitorXa.Services;
using Xamarin.Forms;
using BiaGlicMonitorXa.Models;

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

			return (!IsBusy && ValorConvertido > 0);
		}

        /// <summary>
        /// Execucao do comando gravar
        /// </summary>
		private async void ExecuteGravarCommand()
		{

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

				double ValorConvertido = 0;
				//tenta converter o valor
				double.TryParse(this.Valor, out ValorConvertido);

				Medicao oMedicao = new Medicao(ValorConvertido);

                //limpa o valor
				Valor = "";

                MsgInfo = "Gravando sua taxa...";
				//Adiciona a medicao ao usuario logado
				await _ApiService.AddMedicao(oMedicao);

				//limpa o valor adicionado
				MsgInfo = $"Última taxa {oMedicao.Valor.ToString()} as {oMedicao.Hora}";

            }
            catch (System.Exception ex)
            {
                MsgInfo = $"Erro: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
		}

      

    }
}
