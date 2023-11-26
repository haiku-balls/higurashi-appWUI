using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test_appR.Char
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class rena : Page
    {
        ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public rena()
        {
            this.InitializeComponent();

            // Show the banner if 'worry' is enabled.
            string localValue = localSettings.Values["isWorryEnabled"] as string;
            Debug.WriteLine("localsetting: " + localValue);
            if (localValue == "true")
            {
                worryBanner.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
        }
    }
}
