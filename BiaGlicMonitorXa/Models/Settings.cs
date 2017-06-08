using System;
using Xamarin.Forms;

namespace BiaGlicMonitorXa.Models
{

    /// <summary>
    /// Classe responsavel por guardar as configuracoes do usuario logado
    /// </summary>
	public static class Settings
	{

        /// <summary>
        /// REtorna se o usuario esta logado/cadastrado ou nao
        /// </summary>
        /// <value><c>true</c> if is logged in; otherwise, <c>false</c>.</value>
        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);

		const string UserNameKey = "UserName";
        public static string UserName
		{
			get
			{
				if (Application.Current.Properties.ContainsKey(UserNameKey))
					return Application.Current.Properties[UserNameKey] as string;
				else
					return "";
			}

			set
			{
				Application.Current.Properties[UserNameKey] = value;
                Application.Current.SavePropertiesAsync();
			}
		}


        const string UserEmailKey = "UserEmail";
		public static string UserEmail
		{
			get
			{
				if (Application.Current.Properties.ContainsKey(UserEmailKey))
					return Application.Current.Properties[UserEmailKey] as string;
				else
					return "";
			}

			set
			{
				Application.Current.Properties[UserEmailKey] = value;
                Application.Current.SavePropertiesAsync();
			}
		}



		const string UserPhoneKey = "UserPhone";
		public static string UserPhone
		{
			get
			{
				if (Application.Current.Properties.ContainsKey(UserPhoneKey))
					return Application.Current.Properties[UserPhoneKey] as string;
				else
					return "";
			}

			set
			{
				Application.Current.Properties[UserPhoneKey] = value;
                Application.Current.SavePropertiesAsync();
			}
		}





		const string UserImageUrlKey = "UserImageUrl";
		public static string UserImageUrl
		{
			get
			{
				if (Application.Current.Properties.ContainsKey(UserImageUrlKey))
					return Application.Current.Properties[UserImageUrlKey] as string;
				else
					return "";
			}

			set
			{
				Application.Current.Properties[UserImageUrlKey] = value;
                Application.Current.SavePropertiesAsync();
			}
		}


        const string AccessTokenKey = "AccessToken";
		public static string AccessToken
		{
			get
			{
				if (Application.Current.Properties.ContainsKey(AccessTokenKey))
					return Application.Current.Properties[AccessTokenKey] as string;
				else
					return "";
			}

			set
			{
				Application.Current.Properties[AccessTokenKey] = value;
                Application.Current.SavePropertiesAsync();
			}
		}




		const string UserIdKey = "UserId";
		public static string UserId
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(UserIdKey))
                    return Application.Current.Properties[UserIdKey] as string;
                else
                    return "";
            }

            set
            {
                Application.Current.Properties[UserIdKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }


		const string AuthTokeyKey = "AuthToken";
		public static string AuthToken
		{
			get
			{
				if (Application.Current.Properties.ContainsKey(AuthTokeyKey))
					return Application.Current.Properties[AuthTokeyKey] as string;
				else
					return "";
			}

			set
			{
				Application.Current.Properties[AuthTokeyKey] = value;
                Application.Current.SavePropertiesAsync();
			}
		}


    }
}
