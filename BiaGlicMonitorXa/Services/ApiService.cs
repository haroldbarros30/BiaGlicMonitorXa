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

[assembly: Dependency(typeof(BiaGlicMonitorXa.Services.ApiService))]
namespace BiaGlicMonitorXa.Services
{
	public class ApiService : IApiService
	{
		//private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

		private static Usuario usuarioLogado = new Usuario()
															{
																Id = "UUID00",
																Nome = "Beatriz",
																Email = "beatriz@teste.com.br",
																Telefone = ""
															};





        private static List<Usuario> usuarios;

		public async Task<List<Usuario>> GetUsuariosAsync()
		{/*
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var response = await httpClient.GetAsync($"{BaseUrl}Usuario").ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
				{
					return JsonConvert.DeserializeObject<List<Usuario>>(
						await new StreamReader(responseStream)
							.ReadToEndAsync().ConfigureAwait(false));
				}
			}

			return null;
			*/

            //alimenta os dados de forma estatica enquanto em desenvolvimento
            if (usuarios == null)
            {
				usuarios = new List<Usuario>();


                Usuario usuario1 = new Usuario()
                {
                    Id = "UUID00",
                    Nome = "Beatriz",
                    Email = "beatriz@teste.com.br",
                    Telefone = ""
                };

                usuarioLogado = usuario1;

                Medicao medicao1 = new Medicao()
                {
                    Id = "001",
                    Data = "20170101",
                    Hora = "12:00:00",
                    Valor = 100
                };


				Medicao medicao2 = new Medicao()
				{
					Id = "002",
					Data = "20170101",
					Hora = "12:00:02",
					Valor = 200
				};

				Medicao medicao3 = new Medicao()
				{
					Id = "003",
					Data = "20170101",
					Hora = "12:00:03",
					Valor = 300
				};


				Medicao medicao4 = new Medicao()
				{
					Id = "004",
					Data = "20170104",
					Hora = "12:00:00",
					Valor = 400
				};

				Medicao medicao5 = new Medicao()
				{
					Id = "005",
					Data = "20170105",
					Hora = "12:00:00",
					Valor = 500
				};

                usuario1.Medicoes = new List<Medicao>();
                usuario1.Medicoes.Add(medicao1);
                usuario1.Medicoes.Add(medicao2);
                usuario1.Medicoes.Add(medicao3);
                usuario1.Medicoes.Add(medicao4);
                usuario1.Medicoes.Add(medicao5);

				Usuario usuario2 = new Usuario()
                {
                    Id = "UUID01",
                    Nome = "Paulo",
                    Email = "Paulo@teste.com.br",
                    Telefone = ""
                };

				usuario2.Medicoes = new List<Medicao>();
				usuario2.Medicoes.Add(medicao1);
				usuario2.Medicoes.Add(medicao2);
				usuario2.Medicoes.Add(medicao3);

                Usuario usuario3 =  new Usuario() 
                { 
                    Id = "UUID02",
                    Nome = "Pedro", 
                    Email = "pedro@teste.com.br", 
                    Telefone = "" 
                };

				usuario3.Medicoes = new List<Medicao>();
				usuario3.Medicoes.Add(medicao4);
				usuario3.Medicoes.Add(medicao5);

                usuarios.Add(usuario1);
                usuarios.Add(usuario2);
                usuarios.Add(usuario3);

			}


            return usuarios;
		}

        public async Task AddMedicao(Medicao pMedicao)
        {
            usuarioLogado.Medicoes.Add(pMedicao);
        }

		public async Task<List<Medicao>> GetMedicaoAsync(string pUsuarioId)
		{
            /*
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var response = await httpClient.GetAsync($"{BaseUrl}Usuario/Medicao?usuario={pUsuarioId}").ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
				{
					return JsonConvert.DeserializeObject<List<Medicao>>(
						await new StreamReader(responseStream)
							.ReadToEndAsync().ConfigureAwait(false));
				}
			}

			return null;
			*/


            if (usuarios == null)
            {
                await GetUsuariosAsync();
            }

            if (usuarios == null)
                return null;


            foreach (var item in usuarios)
            {
                if (item.Id.Equals(pUsuarioId))
                    return item.Medicoes;
            }

            return null;


        }

        public Usuario GetUsuarioLogado()
        {
            return usuarioLogado;
        }
    }
}
