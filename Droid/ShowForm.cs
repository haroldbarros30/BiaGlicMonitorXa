using System;
namespace BiaGlicMonitorXa.Droid
{
    public class ShowForm
    {
        public ShowForm()
        {
            PushPage();
        }



 		async static public void PushPage()
		{
			MainActivity.CurrentActivity.RunOnUiThread(() =>
			{
				// Do some Android specific things... and then push a new Forms' Page
				Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new AddMedicaoPage());
			});
		}

    }
}
