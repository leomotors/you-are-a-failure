using Windows.ApplicationModel.DataTransfer;
using Windows.System.UserProfile;
using Windows.UI;

#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// Statisics Page, contains the date you completed the
/// treatment, streaks, analysis, etc.
/// </summary>
public sealed partial class Statistics : Page {
    private readonly DateTime Today;
    private int? current;
    private int? longest;

    public Statistics() {
        this.InitializeComponent();

        var now = DateTime.Now;
        Today = new(now.Year, now.Month, now.Day);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
        WatchStatus.Text = "Today Status: "
            + (App.Current.State.IsAllWatched
                ? "Treatment Completed! ✅"
                : "Go back and watch the video!");

        FailureCalendar.FirstDayOfWeek = GlobalizationPreferences.WeekStartsOn;
        FailureCalendar.CalendarIdentifier = GlobalizationPreferences.Calendars[0];

        current = App.Current.State.ComputeCurrentStreak();
        longest = App.Current.State.ComputeLongestStreak();

        CurrentStreak.Text = $"Current Streak: {current}";
        LongestStreak.Text = $"Longest Streak: {longest}";

        UserRole.Text = Classes.Role.GetRole(
            (int)current, "✨Your Current Role: ", "✨"
        );

        base.OnNavigatedTo(e);
    }

    private readonly SolidColorBrush CalenderColor =
        new((Color)Application.Current.Resources[
            App.Current.IsLightTheme ? "SystemAccentColorLight2" : "SystemAccentColorDark2"]);

    private readonly SolidColorBrush TransparentBrush = new(Colors.Transparent);

    private void FailureCalendar_DayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args) {
        var dateOffset = args.Item.Date;
        DateTime date = new(dateOffset.Year, dateOffset.Month, dateOffset.Day);

        var color =
            App.Current.State.WatchedDate.Contains(date) && date != Today
                ? CalenderColor
                : TransparentBrush;

        // https://blog.mzikmund.com/2020/07/highlighting-dates-in-uwp-calendarview/#comments
        args.Item.Background = color;
    }

    private async void ShareButton_Click(object sender, RoutedEventArgs e) {
        ShareButton.IsEnabled = false;
        CopiedMessage.Visibility = Visibility.Visible;

        var dataPackage = new DataPackage();
        dataPackage.SetText(
            "Yo Angelo! I have watched this *emotional damage* videos "
                + $"for **{current}** days straight!\n"
                + $"Check this out! {Classes.Constants.MSStoreLink}"
        );
        Clipboard.SetContent(dataPackage);

        await Task.Delay(3000);

        ShareButton.IsEnabled = true;
        CopiedMessage.Visibility = Visibility.Collapsed;
    }
}
