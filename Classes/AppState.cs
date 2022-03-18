using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

#nullable enable

namespace you_are_a_failure.Classes;

internal class ParseSaveException : Exception
{
    public ParseSaveException(string message) : base(message)
    {
    }
}

public partial class AppState
{
    // Database Section

    private const string FileName = "chronicle.failure";
    private const int SaveVersion = 1;
    private const string VersionSpec = "VERSION";
    private readonly DateTime Today;

    public List<DateTime>? WatchedDate;

    public AppState()
    {
        var now = DateTime.Now;
        Today = new DateTime(now.Year, now.Month, now.Day);

        System.Diagnostics.Debug.WriteLine($"Today: {Today}");

        LoadDatabase();
    }

    private async void LoadDatabase()
    {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            FileName, CreationCollisionOption.OpenIfExists);

        var lines = (await FileIO.ReadTextAsync(sf)).Split("\n");

        WatchedDate = new();

        try
        {
            if (lines.Length < 2)
            {
                throw new ParseSaveException("Empty Save File");
            }

            var versionLock = lines[0].Split(" ");
            if (versionLock[0] != VersionSpec || int.Parse(versionLock[1]) != SaveVersion)
            {
                // No Database Migration Yet
                throw new ParseSaveException("Invalid Version or Save File Not Exist");
            }

            foreach (var line in lines.Skip(1))
            {
                var tokens = line.Split(" ");

                if (tokens.Length == 3 &&
                    int.TryParse(tokens[0], out int y) &&
                    int.TryParse(tokens[1], out int m) &&
                    int.TryParse(tokens[2], out int d) &&
                    m >= 1 && m <= 12 &&
                    d >= 1 && d <= 31
                )
                {
                    WatchedDate.Add(new DateTime(y, m, d));
                }
            }
        }
        catch (ParseSaveException)
        {
            await SaveDatabase();
        }

        if (WatchedDate.Count > 0 && WatchedDate.Last() == Today)
        {
            for (int i = 0; i < Steven.VideoList.Length; i++)
            {
                Watched[i] = true;
            }

            IsAllWatched = true;
        }
    }

    public async Task SaveDatabase()
    {
        var content = $"{VersionSpec} {SaveVersion}\n";

        foreach (var date in WatchedDate ?? new List<DateTime>())
        {
            content += $"{date.Year} {date.Month} {date.Day}\n";
        }

        var targetFile =
            await ApplicationData.Current.RoamingFolder.GetFileAsync(FileName);

        await FileIO.WriteTextAsync(targetFile, content);
    }
}

public partial class AppState
{
    // Local State Section

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
            if (WatchedDate.Last() != Today)
            {
                WatchedDate!.Add(Today);
                _ = SaveDatabase();
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
