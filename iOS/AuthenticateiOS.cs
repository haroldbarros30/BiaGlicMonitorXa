using System;
using System.Threading.Tasks;
using BiaGlicMonitorXa.iOS;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateiOS))]
namespace BiaGlicMonitorXa.iOS
{
	public class AuthenticateiOS : IAuthenticate
	{
		public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
		{
			try
			{
				return await client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
			}
			catch (Exception ex)
			{
				return null;
			}

		}
	}
}

