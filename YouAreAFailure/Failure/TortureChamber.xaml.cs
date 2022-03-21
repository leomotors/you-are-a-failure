﻿using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;

#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// The place where treatment is given. <b>Not</b> torture chamber like its name.
/// </summary>
public sealed partial class TortureChamber : Page {
    private bool FailuredStarted = false;
    private string? VideoName;

    public TortureChamber() {
        this.InitializeComponent();
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e) {
        FailurePlayer.MediaPlayer.Dispose();
        base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
        FailurePlayer.MediaPlayer.PlaybackSession.PlaybackStateChanged
            += OnFailureVideoStateChanged;

        var param = e.Parameter as Classes.Video;
        VideoName = param?.FileName;
        ItalicBoldBoi.Text = VideoName + '!';

        FailurePlayer.MediaPlayer.MediaOpened += (sender, args) => {
            sender.SystemMediaTransportControls.IsEnabled = false;
        };

        FailurePlayer.Source = MediaSource.CreateFromUri(
            new Uri(
                $"ms-appx:///{Classes.Steven.VideoRoot}/{VideoName}.{Classes.Steven.VideoExtension}"
                )
            );

        FailurePlayer.MediaPlayer.Volume = param?.Volume ?? 1;

        FooterTextBlock.Text =
            App.Current.State.Watched[(int)Classes.AppState.GetIndex(VideoName!)!]
                ? "👍You have already completed this Treatment👍"
                : "";

        base.OnNavigatedTo(e);
    }

    private async void OnFailureVideoStateChanged(MediaPlaybackSession sender, object args) {
        if (sender is null || sender.NaturalVideoHeight == 0) {
            return;
        }

        if (sender.PlaybackState == MediaPlaybackState.Playing) {
            FailuredStarted = true;
        } else if (sender.PlaybackState == MediaPlaybackState.Paused) {
            if (FailuredStarted) {
                App.Current.State.AddWatched(VideoName!);

                // https://social.msdn.microsoft.com/Forums/sqlserver/en-US/49426c88-fb6e-4894-b5ea-25d0f38b3358/uwpthe-application-called-an-interface-that-was-marshalled-for-a-different-thread?forum=wpdevelop
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                    FooterTextBlock.Text =
                        "👍You just completed your Treatment, That is Emotional Damage👍";
                });
            }
        }
    }
}