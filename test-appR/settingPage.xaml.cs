using Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test_appR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class settingPage : Page
    {
        ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public settingPage()
        {
            this.InitializeComponent();

            // Load save states. (This ensures settings isn't OOD with values)
            string localValue = localSettings.Values["isWorryEnabled"] as string;
            Debug.WriteLine("localsetting: " + localValue);
            if (localValue == null)
            {
                return;
            }
            else if ((string) localSettings.Values["isWorryEnabled"] == "true")
            {
                jailSwitch.IsOn = true;
            }
            else if ((string) localSettings.Values["isWorryEnabled"] == "false")
            {
                jailSwitch.IsOn = false;
            }
        }

        private void jailSwitch_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    localSettings.Values["isWorryEnabled"] = "true";
                    Debug.WriteLine("localsetting was set to: true");
                }
                if (toggleSwitch.IsOn == false)
                {
                    localSettings.Values["isWorryEnabled"] = "false";
                    Debug.WriteLine("localsetting was set to: false");
                }
            }
        }
    }
}
