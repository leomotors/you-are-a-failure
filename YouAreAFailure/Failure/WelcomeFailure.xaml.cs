#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// The welcome page with welcome &amp; motivational message.
/// </summary>
public sealed partial class WelcomeFailure : Page {
    public static Action<Classes.NavigationTarget>? Navigator;

    public WelcomeFailure() {
        this.InitializeComponent();
    }

    private void GoWatch_Click(object sender, RoutedEventArgs e) {
        if (Navigator is not null) {
            Navigator(Classes.NavigationTarget.MotivationalVideo);
        }
    }

    private void SeeStats_Click(object sender, RoutedEventArgs e) {
        if (Navigator is not null) {
            Navigator(Classes.NavigationTarget.Statistics);
        }
    }
}
