﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace you_are_a_failure.Classes;

public partial class AppState
{
    public int ComputeCurrentStreak()
    {
        if (WatchedDate is null || WatchedDate.Count < 1) return 0;

        var oneday = new TimeSpan(1, 0, 0, 0);

        if (Today - WatchedDate.Last() > oneday) return 0;

        for (int i = WatchedDate.Count - 1; i > 0; i--)
        {
            if (WatchedDate[i] - WatchedDate[i - 1] != oneday)
            {
                return WatchedDate.Count - i;
            }
        }

        return WatchedDate.Count;
    }

    public int ComputeLongestStreak()
    {
        if (WatchedDate is null || WatchedDate.Count < 1) return 0;

        var oneday = new TimeSpan(1, 0, 0, 0);

        int maxStreak = 0;
        int currStreak = 0;
        for (int i = 1; i < WatchedDate.Count; i++)
        {
            if (WatchedDate[i] - WatchedDate[i - 1] == oneday)
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
