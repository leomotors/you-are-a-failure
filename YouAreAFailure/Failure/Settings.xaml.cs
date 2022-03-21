using Windows.Storage;
using Windows.System;
using Windows.UI;

#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// Settings Page, Also contains information about app &amp; credits.
/// </summary>
public sealed partial class Settings : Page {
    // From Alert Box at System > Display > Custom Scaling
    private readonly SolidColorBrush BackgroundYellow = new(
            App.Current.IsLightTheme
                ? Color.FromArgb(255, 255, 244, 206)
                : Color.FromArgb(255, 67, 53, 25)
        );

    // From Alert Box at System > Display > Custom Scaling
    private readonly SolidColorBrush ForegroundYellow = new(
            App.Current.IsLightTheme
                ? Color.FromArgb(255, 157, 93, 0)
                : Color.FromArgb(255, 252, 225, 0)
        );

    public Settings() {
        this.InitializeComponent();

        // Copied from rabbit-house-menu which is from microsoft/Xaml-Controls-Gallery
        var version = Windows.ApplicationModel.Package.Current.Id.Version;
        AppVersion.Text =
            $"Version: {version.Major}.{version.Minor} Build {version.Build}.{version.Revision}"
#if DEBUG
            + " (DEBUG)"
#endif
            ;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
        Array.ForEach(
            Classes.Steven.VideoList,
            video => CreditsPanel.Children.Add(
                new HyperlinkButton {
                    NavigateUri = new Uri(video.YoutubeLink),
                    Content = "Compilation Video: " + video.FileName,
                }
            )
        );

        base.OnNavigatedTo(e);
    }

    // Copied from rabbit-house-menu
    private async void ViewLicense_Click(object sender, RoutedEventArgs e) {
        var License = await FileIO.ReadTextAsync(
                await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri("ms-appx:///LICENSE")
                )
            );

        const string tmpToken = "__@$";

        var tokens = License.Split("\n");

        var dialog = new ContentDialog {
            Title = tokens[0],
            // Remove "\n" but not "\n\n"
            Content = string.Join("\n", tokens.Skip(2))
                        .Replace("\n\n", tmpToken)
                        .Replace("\n", " ")
                        .Replace(tmpToken, "\n\n"),
            CloseButtonText = "Close",
        };

        await dialog.ShowAsync();
    }

    private void ThemeSelector_Loaded(object sender, RoutedEventArgs e) {
        (sender as MUXC.RadioButtons)!.SelectedIndex = App.Current.CurrentTheme;
    }

    private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var buttons = sender as MUXC.RadioButtons;

        ApplicationData.Current.LocalSettings.Values["themeSetting"] =
            buttons!.SelectedIndex;

        ThemeChangeAlertBorder.Visibility =
            App.Current.CurrentTheme == buttons.SelectedIndex
                ? Visibility.Collapsed : Visibility.Visible;
    }

    private async void OpenSave_Click(object sender, RoutedEventArgs e) {
        var folder = ApplicationData.Current.RoamingFolder;
        await Launcher.LaunchFolderAsync(folder);
    }

    private async void ResetData_Click(object sender, RoutedEventArgs e) {
        var dialog = new ContentDialog {
            Title = "Resetting App Data",
            Content =
                "This will reset all your treatment statistics. This Action is not reversible!",
            DefaultButton = ContentDialogButton.Primary,
            PrimaryButtonText = "Let's Go",
            SecondaryButtonText = "Don't Click",
            CloseButtonText = "断る",
        };

        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary) {
            App.Current.State.WatchedDate = new();
            await App.Current.State.SaveDatabase();
            App.Current.State.ResetTodayWatched();
        } else if (result == ContentDialogResult.Secondary) {
            await Launcher.LaunchUriAsync(
                new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
            );
        }
    }
}
