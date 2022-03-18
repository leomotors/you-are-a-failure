using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace you_are_a_failure.Classes;

public partial class AppState
{
    public readonly bool[] Watched = new bool[Steven.VideoList.Length];

    public Action? OnStateChanged;

    static public int? GetIndex(string key)
    {
        for (int i = 0; i < Steven.VideoList.Length; i++)
        {
            if (Steven.VideoList[i].FileName == key)
            {
                return i;
            }
        }
        return null;
    }

    public bool IsAllWatched { get; private set; }

    public void AddWatched(string key)
    {
        Watched[(int)GetIndex(key)!] = true;

        SetAllWatched();

        if (OnStateChanged is not null) OnStateChanged();

        if (IsAllWatched)
        {
            if (WatchedDate.Count == 0 || WatchedDate.Last() != Today)
            {
                WatchedDate!.Add(Today);
                DatabaseReady = SaveDatabase();
            }
        }
    }

    private void SetAllWatched()
    {
        bool result = true;

        Array.ForEach(Watched, w => result &= w);

        IsAllWatched = result;
    }
}
