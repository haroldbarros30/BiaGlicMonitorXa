using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace BiaGlicMonitorXa
{
	public interface IAuthenticate
	{
		Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
	}
}