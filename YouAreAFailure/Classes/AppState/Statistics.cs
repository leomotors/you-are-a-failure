#nullable enable

namespace YouAreAFailure.Classes;

public partial class AppState {
    // Computation related section

    private readonly TimeSpan oneday = new(1, 0, 0, 0);

    public int ComputeCurrentStreak() {
        if (WatchedDate is null || WatchedDate.Count < 1) {
            return 0;
        }

        if (Today - WatchedDate.Last() > oneday) {
            return 0;
        }

        for (var i = WatchedDate.Count - 1; i > 0; i--) {
            if (WatchedDate[i] - WatchedDate[i - 1] != oneday) {
                return WatchedDate.Count - i;
            }
        }

        return WatchedDate.Count;
    }

    public int ComputeLongestStreak() {
        if (WatchedDate is null || WatchedDate.Count < 1) {
            return 0;
        }

        var maxStreak = 0;
        var currStreak = 0;
        for (var i = 1; i < WatchedDate.Count; i++) {
            if (WatchedDate[i] - WatchedDate[i - 1] == oneday) {
                currStreak++;
            } else {
                maxStreak = Math.Max(maxStreak, currStreak);
                currStreak = 0;
            }
        }

        maxStreak = Math.Max(maxStreak, currStreak);
        return maxStreak + 1;
    }
}
