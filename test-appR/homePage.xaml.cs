using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using test_appR.Lists;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test_appR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class homePage : Page
    {
        private List<Character> Chars;

        public homePage()
        {
            this.InitializeComponent();

            Chars = CharsManager.GetChars();
        }

        // e.ClickedItem.Tag.ToString();
        // this.Frame.Navigate(typeof(rena));

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (Character)e.ClickedItem;
            SelectionOutput.Text = "You selected " + item.Name;
        }
    }
}
