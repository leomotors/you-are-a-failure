#nullable enable

namespace YouAreAFailure.Classes;

public partial class AppState
{
    // Local State, Watched Video section

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
