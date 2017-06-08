using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BiaGlicMonitorXa.Models
{
	/// <summary>
	/// Classe responsavel por guardar as informacoes apos realizado o SocialLogin
	/// Exemplo utilizado da seguinte fonte: https://github.com/rubgithub/JogoDaVelhaMaratonaXamarin/blob/master/JogoDaVelhaMaratona/JogoDaVelhaMaratona/Model/AppServiceIdentity.cs
	/// </summary>
	public class AppServiceIdentity
	{
		[JsonProperty(PropertyName = "id_token")]
		public string IdToken { get; set; }

		[JsonProperty(PropertyName = "access_token")]
		public string AccessToken { get; set; }

		[JsonProperty(PropertyName = "provider_name")]
		public string ProviderName { get; set; }

		[JsonProperty(PropertyName = "user_id")]
		public string UserId { get; set; }

		[JsonProperty(PropertyName = "user_claims")]
		public List<UserClaim> UserClaims { get; set; }
	}

	public class UserClaim
	{
		[JsonProperty(PropertyName = "typ")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "val")]
		public string Value { get; set; }
	}
}
