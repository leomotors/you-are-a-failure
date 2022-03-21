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

        UserRole.Text = Classes.Role.GetRole((int)longest, "✨Your Role: ", "✨");

        base.OnNavigatedTo(e);
    }

    // https://blog.mzikmund.com/2020/07/highlighting-dates-in-uwp-calendarview/#comments
    private void HighlightDay(CalendarViewDayItem day, Color color) {
        day.Background = new SolidColorBrush(color);
    }

    private readonly Color AkiColor =
        App.Current.IsLightTheme
            ? Color.FromArgb(255, 111, 159, 216)
            : Color.FromArgb(255, 36, 44, 80);

    private void FailureCalendar_DayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args) {
        var dateOffset = args.Item.Date;
        DateTime date = new(dateOffset.Year, dateOffset.Month, dateOffset.Day);

        var color =
            App.Current.State.WatchedDate.Contains(date) && date != Today
                ? AkiColor
                : Colors.Transparent;

        HighlightDay(args.Item, color);
    }

    private async void ShareButton_Click(object sender, RoutedEventArgs e) {
        ShareButton.IsEnabled = false;
        CopiedMessage.Visibility = Visibility.Visible;

        var dataPackage = new DataPackage();
        dataPackage.SetText(
            "Yo Angelo! I have watched this *emotional damage* videos"
                + $"for **{current}** days straight!\n"
                + $"Check this out! {Classes.Constants.MSStoreLink}"
        );
        Clipboard.SetContent(dataPackage);

        await Task.Delay(3000);

        ShareButton.IsEnabled = true;
        CopiedMessage.Visibility = Visibility.Collapsed;
    }
}
