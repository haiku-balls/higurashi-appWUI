using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Core;
using Windows.Media.Playback;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test_appR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class soundtrack : Page
    {
        MediaPlayer mediaPlayer = new MediaPlayer();

        public soundtrack()
        {
            this.InitializeComponent();
        }

        private void track1_Click(object sender, RoutedEventArgs e)
        {
            // mediaPlayer.Dispose();
            string trackName = "Shizu";
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/BGM/shizu.mp3"));
            mediaPlayer.Play();
            playingText.Header = "Currently Playing: " + trackName;
        }

        private void stopPlayer_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            playingText.Header = "Currently Playing: Nothing!";
        }

        private void track2_Click(object sender, RoutedEventArgs e)
        {
            // mediaPlayer.Dispose();
            string trackName = "Shitsui";
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/BGM/shitsui.mp3"));
            mediaPlayer.Play();
            playingText.Header = "Currently Playing: " + trackName;
        }
    }
}
