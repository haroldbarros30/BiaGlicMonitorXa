using System;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Droid;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace BiaGlicMonitorXa.Droid
{

	public class AuthenticateDroid : IAuthenticate
	{
		public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
		{

			try
			{
				return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
			}
			catch (Exception ex)
			{
				return null;
			}

		}
	}
}

