using Microsoft.UI;           // Needed for WindowId
using Microsoft.UI.Windowing; // Needed for AppWindow
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using System;
using System.Threading;
using Windows.Storage;
using WinRT.Interop;          // Needed for XAML/HWND interop   

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test_appR
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        private OverlappedPresenter _presenter;

        private AppWindow m_AppWindow;
        public MainWindow()
        {
            this.InitializeComponent();
            m_AppWindow = GetAppWindowForCurrentWindow();
            var titleBar = m_AppWindow.TitleBar;
            // Hide default title bar.
            titleBar.ExtendsContentIntoTitleBar = true;
            Title = "Higurashi Wiki App";
            m_AppWindow.SetIcon("Assets/programIcon.ico");

            // This disables the ability to resize and maximize the window.
            // This is a temporary fix to preventing users to resizing the window causing most pages to scale terribly.
            _presenter = m_AppWindow.Presenter as OverlappedPresenter;
            _presenter.IsResizable = false;
            _presenter.IsMaximizable = false;

            // Initialize save states.
            // Never used this before; instead I used GLOBALS for other projects.

            if (localSettings.Values["isWorryEnabled"] == null)
            {
                localSettings.Values["isWorryEnabled"] = "false";
            } else
            {
                return;
            }

        }

        // SYSTEM FUNCTION, GRABS THE CURRENT WINDOW. SEE MAINWINDOW.
        private AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }

        // From Lovely Reminders (Should handle navi)
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(homePage));
            NavView.SelectedItem = NavView.MenuItems[0];
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // Settings page.
                contentFrame.Navigate(typeof(settingPage));
            }
            else
            {
                // Everything else.
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "home":
                        contentFrame.Navigate(typeof(homePage));
                        break;
                    case "ost_nav":
                        contentFrame.Navigate(typeof(soundtrack));
                        break;
                    case "keiichi_nav":
                        contentFrame.Navigate(typeof(Char.keiichi));
                        break;
                    case "rena_nav":
                        contentFrame.Navigate(typeof(Char.rena));
                        break;
                    case "mion_nav":
                        contentFrame.Navigate(typeof(Char.mion));
                        break;
                    case "shion_nav":
                        contentFrame.Navigate(typeof(Char.shion));
                        break;
                    case "satoko_nav":
                        contentFrame.Navigate(typeof(Char.satoko));
                        break;
                    case "rika_nav":
                        contentFrame.Navigate(typeof(Char.rika));
                        break;
                    case "hanyu_nav":
                        contentFrame.Navigate(typeof(Char.hanyu));
                        break;

                    // Footer
                    case "about":
                        contentFrame.Navigate(typeof(Info));
                        break;
                }
            }
        }

        private void NavView_PaneClosed(NavigationView sender, object args)
        {
            NavView.IsPaneOpen = true;
        }
    }
}
