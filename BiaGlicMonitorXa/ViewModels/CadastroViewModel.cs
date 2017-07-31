using System;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using BiaGlicMonitorXa.Services;
using BiaGlicMonitorXa.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace BiaGlicMonitorXa
{
    public class CadastroViewModel: BaseViewModel
    {
        private readonly IApiService _ApiService;

		public CadastroViewModel(IApiService ApiService)
		{
			_ApiService = ApiService;
            GravarCommand = new Command(ExecuteGravarCommand, CanExecuteGravarCommand);
            LoginFaceBookCommand = new Command(ExecuteLoginFaceBookCommand, CanExecuteLoginFaceBookCommand); 
			Title = "Login/Cadastro";
		}

        /// <summary>
        /// Gets the login face book command.
        /// </summary>
        /// <value>The login face book command.</value>
		public Command LoginFaceBookCommand { get; }

        /// <summary>
        /// Cans the execute login face book command.
        /// </summary>
        /// <returns><c>true</c>, if execute login face book command was caned, <c>false</c> otherwise.</returns>
        /// <param name="arg">Argument.</param>
        private bool CanExecuteLoginFaceBookCommand(object arg)
        {
            return !IsBusy;
        }

        /// <summary>
        /// Executes the login face book command.
        /// </summary>
        /// <param name="obj">Object.</param>
        private async void ExecuteLoginFaceBookCommand(object obj)
        {
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;


				Boolean UsuarioLogado = await _ApiService.LoginAsync();

				if (UsuarioLogado)
				{
					this.Info = "Bem vindo!";
					this.Id = Settings.UserId;
					this.Nome = Settings.UserName;
					this.Email = Settings.UserEmail;
					this.Foto = Settings.UserImageUrl;

					//grava o usuario no banco de dados do Azure
					await _ApiService.AddUsuarioAsync(_ApiService.GetUsuarioLogado());
				}
				else
				{
					this.Info = "Falha no login, tente novamente!";
				}

			}
			catch (Exception ex)
			{
				this.Info = $"Erro:{ex.Message}";
			}
			finally
			{
				IsBusy = false;

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
            //verifica se os dados obrigatorios foram preenchidos
            return (!String.IsNullOrWhiteSpace(this.Id) &&
                    !String.IsNullOrWhiteSpace(this.Nome));
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


				//grava os dados do usuario logado
				Settings.UserId = this.Id;
				Settings.UserName = this.Nome;
				Settings.UserEmail = this.Email;
				Settings.UserImageUrl = this.Foto;
				Settings.UserPhone = this.Telefone;

				//grava o usuario no banco de dados do Azure
				await _ApiService.AddUsuarioAsync(_ApiService.GetUsuarioLogado());

				this.Info = "Dados de login cadastrados.";

            }
            catch (Exception ex)
            {
                this.Info = $"Erro:{ex.Message}";
            }
            finally
            {
                IsBusy = false;

            }


		}

		public async override Task LoadAsync()
		{
			//preenche os dados conforme o usuario logado
            this.Id   = Settings.UserId;
			this.Nome = Settings.UserName;
			this.Email = Settings.UserEmail;
			this.Foto = Settings.UserImageUrl;
			this.Telefone = Settings.UserPhone;
		}

        private string _Id;
		public string Id
		{
			get { return _Id; }
			set
			{
				SetProperty(ref _Id, value);
                GravarCommand.ChangeCanExecute();
			}
		}

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set
            {
                SetProperty(ref _Nome, value);
                GravarCommand.ChangeCanExecute();
            }
        }


		private string _Email;
		public string Email
		{
			get { return _Email; }
			set
			{
				SetProperty(ref _Email, value);
			}
		}


		private string _Telefone;
		public string Telefone
		{
			get { return _Telefone; }
			set
			{
				SetProperty(ref _Telefone, value);
			}
		}



        private string _Info;
        public string Info
        {
            get { return _Info; }
            set
            {
                SetProperty(ref _Info, value);
            }
        }


		private string _Foto;
		public string Foto
		{
			get { return _Foto; }
			set
			{
				SetProperty(ref _Foto, value);
			}
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

    }
}
