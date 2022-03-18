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
/// An empty page that can be used on its own or navigated to within a Frame.
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
}
