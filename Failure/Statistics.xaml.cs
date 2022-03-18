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
using Windows.System.UserProfile;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace you_are_a_failure.Failure;

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

    private int ComputeCurrentStreak()
    {
        var dates = App.Current.State.WatchedDate;

        if (dates.Count < 1) return 0;

        var oneday = new TimeSpan(1, 0, 0, 0);

        if (Today - dates.Last() > oneday) return 0;

        for (int i = dates.Count - 1; i > 0; i--)
        {
            if (dates[i] - dates[i - 1] != oneday)
            {
                return dates.Count - i;
            }
        }

        return dates.Count;
    }

    private int ComputeLongestStreak()
    {
        var dates = App.Current.State.WatchedDate;

        if (dates.Count < 1) return 0;

        var oneday = new TimeSpan(1, 0, 0, 0);

        int maxStreak = 0;
        int currStreak = 0;
        for (int i = 1; i < dates.Count; i++)
        {
            if (dates[i] - dates[i - 1] == oneday)
            {
                currStreak++;
            }
            else
            {
                maxStreak = Math.Max(maxStreak, currStreak);
                currStreak = 0;
            }
        }

        return maxStreak + 1;
    }
}
