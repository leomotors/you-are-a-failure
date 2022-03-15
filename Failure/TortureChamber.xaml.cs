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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace you_are_a_failure.Failure;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class TortureChamber : Page
{
    private bool FailuredStarted { get; set; }

    public TortureChamber()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        FailurePlayer.MediaPlayer.PlaybackSession.PlaybackStateChanged
            += OnFailureVideoStateChanged;

        base.OnNavigatedTo(e);
    }

    private void OnFailureVideoStateChanged(MediaPlaybackSession sender, object args)
    {
        if (sender == null || sender.NaturalVideoHeight == 0) return;

        System.Diagnostics.Debug.WriteLine(sender.PlaybackState);

        if (sender.PlaybackState == MediaPlaybackState.Playing)
        {
            FailuredStarted = true;
            return;
        }

        if (sender.PlaybackState == MediaPlaybackState.Paused)
        {
            if (!FailuredStarted) return;

            System.Diagnostics.Debug.WriteLine("Failure has ended! ==========>");
        }
    }
}
