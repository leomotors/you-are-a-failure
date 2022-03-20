﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using Windows.ApplicationModel;
global using Windows.ApplicationModel.Activation;
global using Windows.UI.Xaml;
global using Windows.UI.Xaml.Controls;
global using Windows.UI.Xaml.Media;
global using Windows.UI.Xaml.Navigation;

global using MUXC = Microsoft.UI.Xaml.Controls;

using Windows.Storage;

#nullable enable

namespace YouAreAFailure;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application {

    public readonly int CurrentTheme =
        ApplicationData.Current.LocalSettings.Values["themeSetting"] as int? ?? 2;

    public readonly bool IsLightTheme;

    public static new App Current => (Application.Current as App)!;

    public readonly Classes.AppState State;

    /// <summary>
    /// Initializes the singleton application object. This is the first line of
    /// authored code executed, and as such is the logical equivalent of main()
    /// or WinMain().
    /// </summary>
    public App() {
        this.InitializeComponent();
        this.Suspending += OnSuspending;

        State = new Classes.AppState();

        // Set App Theme based on Settings
        switch (CurrentTheme) {
            case 0:
                RequestedTheme = ApplicationTheme.Light;
                break;

            case 1:
                RequestedTheme = ApplicationTheme.Dark;
                break;
        }

        IsLightTheme = Application.Current.RequestedTheme == ApplicationTheme.Light;
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user. Other
    /// entry points will be used such as when the application is launched to
    /// open a specific file.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e) {
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (Window.Current.Content is not Frame rootFrame) {
            // Create a Frame to act as the navigation context and navigate to
            // the first page
            rootFrame = new Frame();

            rootFrame.NavigationFailed += OnNavigationFailed;

            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated) {
                //TODO: Load state from previously suspended application
            }

            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        if (e.PrelaunchActivated == false) {
            if (rootFrame.Content == null) {
                // When the navigation stack isn't restored navigate to the
                // first page, configuring the new page by passing required
                // information as a navigation parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
    }

    /// <summary>
    /// Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e) {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    /// <summary>
    /// Invoked when application execution is being suspended. Application state
    /// is saved without knowing whether the application will be terminated or
    /// resumed with the contents of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e) {
        var deferral = e.SuspendingOperation.GetDeferral();
        //TODO: Save application state and stop any background activity
        deferral.Complete();
    }
}
