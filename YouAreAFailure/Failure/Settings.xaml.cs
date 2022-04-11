using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.System;

#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// Settings Page, Also contains information about app &amp; credits.
/// </summary>
public sealed partial class Settings : Page {

    public Settings() {
        this.InitializeComponent();

        // Copied from rabbit-house-menu which is from microsoft/Xaml-Controls-Gallery
        var version = Package.Current.Id.Version;
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
                new Controls.ExternalLink {
                    Text = $"Compilation Video: {video.FileName}",
                    Url = video.YoutubeLink,
                }
            )
        );

        AggressiveSwitch.IsOn =
            ApplicationData.Current.LocalSettings.Values[nameof(Classes.Key.AggressiveMode)]
                as bool? ?? false;

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
        (sender as MUXC.RadioButtons)!.SelectedIndex =
            ApplicationData.Current.LocalSettings.Values[nameof(Classes.Key.ThemeSetting)]
                as int? ?? App.Current.CurrentTheme;
    }

    private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var buttons = sender as MUXC.RadioButtons;

        ApplicationData.Current.LocalSettings.Values[nameof(Classes.Key.ThemeSetting)]
            = buttons!.SelectedIndex;

        ThemeChangeAlert.IsOpen =
            App.Current.CurrentTheme != buttons.SelectedIndex;
    }

    private async void Restart_Click(object sender, RoutedEventArgs e) {
        var result = await CoreApplication.RequestRestartAsync("");

        if (result == AppRestartFailureReason.RestartPending) {
            (ThemeChangeAlert.ActionButton.Content as Button)!.Content = "Restarting...";
            return;
        }

        ThemeChangeInfoBar.Title = "Cannot Restart";
        ThemeChangeInfoBar.Message = $"Failure Reason: {result}, please restart manually";
        ThemeChangeInfoBar.Severity = MUXC.InfoBarSeverity.Error;
        ThemeChangeInfoBar.IsOpen = true;
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
            await Classes.Bruh.RickRoll();
        }
    }

    private async void AggressiveSwitch_Toggled(object sender, RoutedEventArgs e) {
        var tSwitch = (sender as ToggleSwitch)!;
        ApplicationData.Current.LocalSettings.Values[nameof(Classes.Key.AggressiveMode)]
            = tSwitch.IsOn;

        if (!tSwitch.IsOn) {
            var dialog = new ContentDialog {
                Title = "R u sure?",
                Content = "I recommend to you to keep this on, Concentration is the key.",
                DefaultButton = ContentDialogButton.Primary,
                PrimaryButtonText = "Y E S",
                CloseButtonText = "no"
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.None) {
                tSwitch.IsOn = true;
            }
        }
    }
}
