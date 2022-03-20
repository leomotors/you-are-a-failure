using Windows.System.UserProfile;
using Windows.UI;

#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// Statisics Page, contains the date you completed the treatment,
/// streaks, analysis, etc.
/// </summary>
public sealed partial class Statistics : Page
{
    private readonly DateTime Today;

    public Statistics()
    {
        this.InitializeComponent();

        var now = DateTime.Now;
        Today = new(now.Year, now.Month, now.Day);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        WatchStatus.Text = "Today Status: "
            + (App.Current.State.IsAllWatched
                ? "Treatment Completed!"
                : "Go back and watch the video!");

        FailureCalendar.FirstDayOfWeek = GlobalizationPreferences.WeekStartsOn;
        FailureCalendar.CalendarIdentifier = GlobalizationPreferences.Calendars[0];

        var style = Application.Current.Resources["TextXL"] as Style;

        StreakPanel.Children.Add(new TextBlock
        {
            Text = $"Current Streak: {App.Current.State.ComputeCurrentStreak()}",
            Style = style,
        });

        StreakPanel.Children.Add(new TextBlock
        {
            Text = $"Longest Streak: {App.Current.State.ComputeLongestStreak()}",
            Style = style,
        });

        base.OnNavigatedTo(e);
    }

    // https://blog.mzikmund.com/2020/07/highlighting-dates-in-uwp-calendarview/#comments
    private void HighlightDay(CalendarViewDayItem day, Color color)
    {
        day.Background = new SolidColorBrush(color);
    }

    private readonly Color AkiColor =
        App.Current.IsLightTheme
            ? Color.FromArgb(255, 111, 159, 216)
            : Color.FromArgb(255, 36, 44, 80);

    private void FailureCalendar_DayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
    {
        var dateOffset = args.Item.Date;
        DateTime date = new(dateOffset.Year, dateOffset.Month, dateOffset.Day);

        var color =
            App.Current.State.WatchedDate.Contains(date) && date != Today
                ? AkiColor
                : Colors.Transparent;

        HighlightDay(args.Item, color);
    }
}
