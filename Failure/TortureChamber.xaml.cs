using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace you_are_a_failure.Failure;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class TortureChamber : Page
{
    private bool FailuredStarted { get; set; }
    private string VideoName { get; set; }

    public TortureChamber()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        FailurePlayer.MediaPlayer.Dispose();
        base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        FailurePlayer.MediaPlayer.PlaybackSession.PlaybackStateChanged
            += OnFailureVideoStateChanged;

        var param = e.Parameter as Classes.Video;
        VideoName = param?.FileName;
        ItalicBoldBoi.Text = VideoName + '!';

        FailurePlayer.MediaPlayer.MediaOpened += (sender, args) =>
        {
            sender.SystemMediaTransportControls.IsEnabled = false;
        };

        FailurePlayer.Source = MediaSource.CreateFromUri(
            new Uri(
                $"ms-appx:///{Classes.Steven.VideoRoot}/{VideoName}.{Classes.Steven.VideoExtension}"
                )
            );

        FailurePlayer.MediaPlayer.Volume = param?.Volume ?? 1;

        FooterTextBlock.Text =
            Classes.AppState.Watched[(int)Classes.AppState.GetIndex(VideoName)]
                ? "👍You have already completed this Treatment👍"
                : "";

        base.OnNavigatedTo(e);
    }

    private async void OnFailureVideoStateChanged(MediaPlaybackSession sender, object args)
    {
        if (sender is null || sender.NaturalVideoHeight == 0) return;

        if (sender.PlaybackState == MediaPlaybackState.Playing)
        {
            FailuredStarted = true;
        }
        else if (sender.PlaybackState == MediaPlaybackState.Paused)
        {
            if (FailuredStarted)
            {
                Classes.AppState.AddWatched(VideoName);

                // https://social.msdn.microsoft.com/Forums/sqlserver/en-US/49426c88-fb6e-4894-b5ea-25d0f38b3358/uwpthe-application-called-an-interface-that-was-marshalled-for-a-different-thread?forum=wpdevelop
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    FooterTextBlock.Text =
                        "👍You just completed your Treatment, That is Emotional Damage👍";
                });
            }
        }
    }
}
