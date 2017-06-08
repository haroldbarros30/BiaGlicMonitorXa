using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace BiaGlicMonitorXa.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
