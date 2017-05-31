using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(BiaGlicMonitorXa.Services.ApiService))]
namespace BiaGlicMonitorXa.Services
{
	public class ApiService : IApiService
	{
		private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

		public async Task<List<Usuario>> GetUsuariosAsync()
		{
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
		}

		public async Task<List<Medicao>> GetMedicaoAsync(string pUsuarioId)
		{
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
		}
	}
}
