using System;
namespace BiaGlicMonitorXa.Models
{

	/// <summary>
	/// Fonte: https://github.com/rubgithub/JogoDaVelhaMaratonaXamarin/blob/master/JogoDaVelhaMaratona/JogoDaVelhaMaratona/Model/FacebookProfile.cs
	/// </summary>
	public class FacebookProfile
	{
		public Picture Picture { get; set; }
	}

	public class Picture
	{
		public Data Data { get; set; }
	}

	public class Data
	{
		public bool IsSilhouette { get; set; }
		public string Url { get; set; }
	}
	
}
