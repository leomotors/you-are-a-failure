﻿#nullable enable

namespace YouAreAFailure.Classes;

public partial class AppState {
    // Local State, Watched Video section

    public readonly bool[] Watched = new bool[Steven.VideoList.Length];

    public Action? OnStateChanged;

    public int videoDismissed = 0;

    public static int? GetIndex(string key) {
        for (var i = 0; i < Steven.VideoList.Length; i++) {
            if (Steven.VideoList[i].FileName == key) {
                return i;
            }
        }
        return null;
    }

    public bool IsAllWatched { get; private set; }

    public void AddWatched(string key) {
        Watched[(int)GetIndex(key)!] = true;

        SetAllWatched();

        if (OnStateChanged is not null) {
            OnStateChanged();
        }

        if (IsAllWatched) {
            if (WatchedDate.Count == 0 || WatchedDate.Last() != Today) {
                WatchedDate!.Add(Today);
                DatabaseReady = SaveDatabase();
            }
        }
    }

    private void SetAllWatched() {
        var result = true;

        Array.ForEach(Watched, w => result &= w);

        IsAllWatched = result;
    }

    public void ResetTodayWatched() {
        for (var i = 0; i < Steven.VideoList?.Length; i++) {
            Watched[i] = false;
        }

        if (OnStateChanged is not null) {
            OnStateChanged();
        }
    }
}
