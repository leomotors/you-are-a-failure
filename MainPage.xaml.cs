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
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace you_are_a_failure;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        // https://docs.microsoft.com/en-us/windows/apps/design/style/mica#title-bar-code-behind

        var titleBar = ApplicationView.GetForCurrentView().TitleBar;

        titleBar.ButtonBackgroundColor = Colors.Transparent;
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

        // Hide default title bar.
        var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
        coreTitleBar.ExtendViewIntoTitleBar = true;
        UpdateTitleBarLayout(coreTitleBar);

        // Set XAML element as a draggable region.
        Window.Current.SetTitleBar(AppTitleBar);

        // Register a handler for when the size of the overlaid caption control changes.
        // For example, when the app moves to a screen with a different DPI.
        coreTitleBar.LayoutMetricsChanged += (sender, args) =>
        {
            UpdateTitleBarLayout(sender);
        };

        // Register a handler for when the title bar visibility changes.
        // For example, when the title bar is invoked in full screen mode.
        coreTitleBar.IsVisibleChanged += (sender, args) =>
        {
            AppTitleBar.Visibility = sender.IsVisible
                                        ? Visibility.Visible
                                        : Visibility.Collapsed;
        };

        //Register a handler for when the window changes focus
        Window.Current.Activated += Current_Activated;

        Failure.VideoList.OnListViewClickHandler = OnVideoListSelected;
    }

    private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
    {
        // Update title bar control size as needed to account for system size changes.
        AppTitleBar.Height = coreTitleBar.Height;

        // Ensure the custom title bar does not overlap window caption controls
        Thickness currMargin = AppTitleBar.Margin;
        AppTitleBar.Margin = new Thickness(currMargin.Left, currMargin.Top, coreTitleBar.SystemOverlayRightInset, currMargin.Bottom);
    }

    // Update the TitleBar based on the inactive/active state of the app
    private void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
    {
        SolidColorBrush defaultForegroundBrush =
            (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"];
        SolidColorBrush inactiveForegroundBrush =
            (SolidColorBrush)Application.Current.Resources["TextFillColorDisabledBrush"];

        if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
        {
            AppTitle.Foreground = inactiveForegroundBrush;
        }
        else
        {
            AppTitle.Foreground = defaultForegroundBrush;
        }
    }

    // Update the TitleBar content layout depending on NavigationView DisplayMode
    private void NavigationViewControl_DisplayModeChanged(MUXC.NavigationView sender, MUXC.NavigationViewDisplayModeChangedEventArgs args)
    {
        const int topIndent = 16;
        const int expandedIndent = 48;
        int minimalIndent = 104;

        // If the back button is not visible, reduce the TitleBar content indent.
        if (NavigationViewControl.IsBackButtonVisible.Equals(MUXC.NavigationViewBackButtonVisible.Collapsed))
        {
            minimalIndent = 48;
        }

        Thickness currMargin = AppTitleBar.Margin;

        // Set the TitleBar margin dependent on NavigationView display mode
        if (sender.PaneDisplayMode == MUXC.NavigationViewPaneDisplayMode.Top)
        {
            AppTitleBar.Margin = new Thickness(topIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
        }
        else if (sender.DisplayMode == MUXC.NavigationViewDisplayMode.Minimal)
        {
            AppTitleBar.Margin = new Thickness(minimalIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
        }
        else
        {
            AppTitleBar.Margin = new Thickness(expandedIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
        }
    }

    private void NavigationView_Loaded(object sender, RoutedEventArgs e)
    {
        NavigationViewControl.SelectedItem = MotivationalVideo;
        MotivationalVideo.IsExpanded = true;

        foreach (var video in Classes.Steven.VideoList)
        {
            MotivationalVideo.MenuItems.Add(new MUXC.NavigationViewItem
            {
                Content = video.FileName
            });
        }
    }

    private void NavigationView_SelectionChanged(MUXC.NavigationView sender, MUXC.NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            FailureFrame.Navigate(typeof(Failure.Settings));
            return;
        }

        var selected = args.SelectedItem as MUXC.NavigationViewItem;

        if (selected == MotivationalVideo)
        {
            FailureFrame.Navigate(typeof(Failure.VideoList));
            return;
        }
        else if (selected == Statistics)
        {
            FailureFrame.Navigate(typeof(Failure.Statistics));
            return;
        }
        else
        {
            if (selected.Content is not string videoName) return;

            Classes.Video selectedVideo =
                Classes.Steven.VideoList.Where(vid => vid.FileName == videoName).First();

            FailureFrame.Navigate(typeof(Failure.TortureChamber), selectedVideo);
        }
    }

    public void OnVideoListSelected(string selected)
    {
        MotivationalVideo.IsExpanded = true;

        NavigationViewControl.SelectedItem =
            MotivationalVideo.MenuItems
            .Where(
                menu => (menu as MUXC.NavigationViewItem).Content as string == selected
            ).First();
    }
}
