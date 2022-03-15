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
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace you_are_a_failure.Failure;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Settings : Page
{
    public Settings()
    {
        this.InitializeComponent();

        // Copied from rabbit-house-menu which is from microsoft/Xaml-Controls-Gallery
        var version = Windows.ApplicationModel.Package.Current.Id.Version;
        AppVersion.Text = $"Version: {version.Major}.{version.Minor} Build {version.Build}.{version.Revision}";
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        foreach (var video in Classes.Steven.VideoList)
        {
            CreditsPanel.Children.Add(new HyperlinkButton
            {
                NavigateUri = new Uri(video.YoutubeLink),
                Content = "Compilation Video: " + video.FileName,
            });
        }

        base.OnNavigatedTo(e);
    }

    // Copied from rabbit-house-menu
    private async void ViewLicense_Click(object sender, RoutedEventArgs e)
    {
        string License = await FileIO.ReadTextAsync(
               await StorageFile.GetFileFromApplicationUriAsync(
                   new Uri("ms-appx:///LICENSE")
               )
           );

        const string tmpToken = "__@$";

        var tokens = License.Split("\n");

        var dialog = new ContentDialog
        {
            Title = tokens[0],
            // Remove "\n" but not "\n\n"
            Content = string.Join("\n", tokens.Skip(2))
                        .Replace("\n\n", tmpToken)
                        .Replace("\n", " ")
                        .Replace(tmpToken, "\n\n"),
            CloseButtonText = "Close"
        };

        await dialog.ShowAsync();
    }
}
