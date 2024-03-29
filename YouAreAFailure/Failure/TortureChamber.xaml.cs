﻿using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Core;

#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// The place where treatment is given. <b>Not</b> torture chamber like its name.
/// </summary>
public sealed partial class TortureChamber : Page {
    private bool FailuredStarted = false;
    private string? VideoName;
    public static Action? OnGoSettings;

    public TortureChamber() {
        this.InitializeComponent();
    }

    protected override async void OnNavigatedFrom(NavigationEventArgs e) {
        FailurePlayer.MediaPlayer.Dispose();

        var state = App.Current.State;

        var aggressiveOn =
            ApplicationData.Current.LocalSettings.Values[nameof(Classes.Key.AggressiveMode)]
                as bool? ?? false;

        if (state.Watched[(int)Classes.AppState.GetIndex(VideoName!)!]) {
            return;
        }

        if (aggressiveOn) {
            _ = Classes.Bruh.RickRoll();

            const string content =
@"Because you leave the video before finishing it, you deserve to be punished!

PS. It is because you have aggressive mode turned on, you turned it on yourself, you forgot?";

            var dialog = new ContentDialog {
                Title = "You have been Rick Rolled!",
                Content = content,
                DefaultButton = ContentDialogButton.Close,
                CloseButtonText = "O_o",
            };

            _ = dialog.ShowAsync();
        } else {
            state.videoDismissed++;

            var content =
                $"You have dismissed the video {state.videoDismissed} times in the row, "
                + "I recommend you to turn on aggressive mode "
                + "so you can better focus and gain motivation!";

            if (state.videoDismissed >= 3) {
                var dialog = new ContentDialog {
                    Title = "Inconsistency Alert!",
                    Content = content,
                    DefaultButton = ContentDialogButton.Primary,
                    PrimaryButtonText = "Go to Settings",
                    SecondaryButtonText = "idk and idc",
                    CloseButtonText = "what",
                };

                var result = await dialog.ShowAsync();

                if (result != ContentDialogResult.None) {
                    state.videoDismissed = int.MinValue;
                }

                if (result == ContentDialogResult.Primary) {
                    if (OnGoSettings is not null) {
                        OnGoSettings();
                    }
                }
            }
        }

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
                var state = App.Current.State;
                state.AddWatched(VideoName!);

                var content = "That is emotional damage!\n\n" +
                    (state.IsAllWatched
                        ? "Good to see that you completed all your treatment for today! Visit Statistics Page to see something interesting!"
                        : "Good luck on continuing your treatment!");

                // https://social.msdn.microsoft.com/Forums/sqlserver/en-US/49426c88-fb6e-4894-b5ea-25d0f38b3358/uwpthe-application-called-an-interface-that-was-marshalled-for-a-different-thread?forum=wpdevelop
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                    FooterTextBlock.Text =
                        "👍You just completed your Treatment, That is Emotional Damage👍";

                    var dialog = new ContentDialog {
                        Title = "Wow! You just completed your Treatment!",
                        Content = content,
                        DefaultButton = ContentDialogButton.Close,
                        CloseButtonText = "ok",
                    };

                    try {
                        _ = dialog.ShowAsync();
                    } catch { }
                });
            }
        }
    }
}
