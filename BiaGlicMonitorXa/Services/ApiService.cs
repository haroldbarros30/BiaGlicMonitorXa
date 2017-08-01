using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Dependency(typeof(BiaGlicMonitorXa.Services.ApiService))]
namespace BiaGlicMonitorXa.Services
{
    public class ApiService : IApiService
    {

        public static readonly string AppUrl = "https://biaglicmonitor.azurewebsites.net";



		List<AppServiceIdentity> identities = null;

		public MobileServiceClient Client { get; set; } = null;
        IMobileServiceTable<Usuario> UsuarioTable;
        IMobileServiceTable<Medicao> MedicaoTable;
		

        public ApiService()
        {
            //cria o MobileService do azure
            Client = new MobileServiceClient(AppUrl);

            //Cria a tabela de usuarios
            UsuarioTable = Client.GetTable<Usuario>();

            //cria a tabela de medicao
            MedicaoTable = Client.GetTable<Medicao>();
        }

        /// <summary>
        /// Realiza o login com o facebook
        /// </summary>
        /// <returns>The async.</returns>
        public async Task<Boolean> LoginAsync()
        {
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;

            if (user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Nao conseguimos efetuar o login, tente novamente", "OK");
                });

                return false;

            }
            else
            {
                //Obs: Exemplo copiado da seguinte fonte: https://github.com/rubgithub/JogoDaVelhaMaratonaXamarin/blob/master/JogoDaVelhaMaratona/JogoDaVelhaMaratona/Service/AzureService.cs

                identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");



                //guarda os dados do usuario localizado
                try
                {
					Settings.UserName = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;
				}
                catch (Exception ex)
                {

                }


                try
                {
					Settings.UserEmail = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")).Value;

				}
                catch (Exception ex)
                {

                }

                /* Algumas outras opcoes possiveis para recuperar dados do facebook

                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender"
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"

                 */

                try
                {
                    Settings.AuthToken = user.MobileServiceAuthenticationToken;
                }
                catch (Exception ex)
                {
                    Settings.AuthToken = DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                try
                {
                    Settings.UserId = user.UserId;
                }
                catch (Exception ex)
                {
                    Settings.UserId = DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                try
                {
                    Settings.AccessToken = identities[0].AccessToken;
                }
                catch (Exception ex)
                {

                }

                try
                {
					//busca a foto do usuario
					var requestUrl = $"https://graph.facebook.com/v2.9/me/?fields=picture.width(350).height(350)&access_token={Settings.AccessToken}";
					var httpClient = new HttpClient();
					var userJson = await httpClient.GetStringAsync(requestUrl);
					var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);
					Settings.UserImageUrl = facebookProfile.Picture.Data.Url;
                }
                catch (Exception ex)
                {

                }
               

            }

            return true;

        }

        /// <summary>
        /// Retorna a lista de usuarios cadastrados
        /// </summary>
        /// <returns>The usuarios async.</returns>
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            IEnumerable<Usuario> usuarios = await UsuarioTable.ToEnumerableAsync();
			return new List<Usuario>(usuarios);
        }


        /// <summary>
        /// Retora se um determinado ID de usuario existe
        /// </summary>
        /// <returns>The usuario exists async.</returns>
        /// <param name="pUsuarioId">P usuario identifier.</param>
        public async Task<Boolean> GetUsuarioExistsAsync(string pUsuarioId)
		{
            var usuarios = await UsuarioTable.Where(u => u.Id == pUsuarioId).ToEnumerableAsync();
            return (usuarios != null && usuarios.Count() > 0);

		}


        /// <summary>
        /// Adiciona um novo usuario
        /// </summary>
        /// <returns>The usuario async.</returns>
        /// <param name="pUsuario">P usuario.</param>
        public async Task AddUsuarioAsync(Usuario pUsuario)
        {
            if (await GetUsuarioExistsAsync(pUsuario.Id))
                await this.UsuarioTable.UpdateAsync(pUsuario);
            else
                await this.UsuarioTable.InsertAsync(pUsuario);
        }

        /// <summary>
        /// Adiciona uma medicao
        /// </summary>
        /// <returns>The medicao.</returns>
        /// <param name="pMedicao">P medicao.</param>
        public async Task AddMedicao(Medicao pMedicao)
        {
            await this.MedicaoTable.InsertAsync(pMedicao);
        }


        /// <summary>
        /// Retorna as medicoes realizadas de um determinado usuario
        /// </summary>
        /// <returns>The medicao async.</returns>
        /// <param name="pUsuarioId">P usuario identifier.</param>
		public async Task<List<Medicao>> GetMedicaoAsync(string pUsuarioId)
		{

            IEnumerable<Medicao> medicoes = await MedicaoTable
                .Where(medicao => medicao.UsuarioId == pUsuarioId)
			    .ToEnumerableAsync();

			return new List<Medicao>(medicoes);
  
        }



        /// <summary>
        /// Retorna com o usuario logado
        /// </summary>
        /// <returns>The usuario logado.</returns>
        public Usuario GetUsuarioLogado()
        {
            Usuario usuarioLogado = new Usuario();
            usuarioLogado.Id = Settings.UserId;
            usuarioLogado.Nome = Settings.UserName;
            usuarioLogado.Email = Settings.UserEmail;
            usuarioLogado.Telefone = Settings.UserPhone;
            return usuarioLogado;
        }
    }
}
