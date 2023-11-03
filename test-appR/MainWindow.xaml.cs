using Microsoft.UI;           // Needed for WindowId
using Microsoft.UI.Windowing; // Needed for AppWindow
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
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
        private AppWindow m_AppWindow;
        public MainWindow()
        {
            this.InitializeComponent();
            m_AppWindow = GetAppWindowForCurrentWindow();
            var titleBar = m_AppWindow.TitleBar;
            // Hide default title bar.
            titleBar.ExtendsContentIntoTitleBar = true;
            Title = "Higurashi Wiki App";
            // m_AppWindow.SetIcon("");
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
                    case "keiichi_nav":
                        contentFrame.Navigate(typeof(Char.keiichi));
                        break;
                    case "rena_nav":
                        contentFrame.Navigate(typeof(Char.rena));
                        break;
                    case "mion_nav":
                        contentFrame.Navigate(typeof(Char.mion));
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
