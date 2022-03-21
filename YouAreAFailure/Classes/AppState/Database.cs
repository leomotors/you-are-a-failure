using Windows.Storage;

#nullable enable

namespace YouAreAFailure.Classes;

internal class ParseSaveException : Exception {
    public ParseSaveException(string message) : base(message) { }
}

public partial class AppState {
    // Database related section

    public const string FileName = "chronicle.failure";
    public const int SaveVersion = 1;
    public const string VersionSpec = "VERSION";
    private readonly DateTime Today;

    public List<DateTime> WatchedDate = new();

    public Task DatabaseReady;

    public AppState() {
        var now = DateTime.Now;
        Today = new DateTime(now.Year, now.Month, now.Day);

        System.Diagnostics.Debug.WriteLine($"Today: {Today}");

        DatabaseReady = LoadDatabase();
    }

    private async Task LoadDatabase() {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            FileName, CreationCollisionOption.OpenIfExists);

        var lines = (await FileIO.ReadTextAsync(sf)).Split("\n");

        try {
            if (lines.Length < 2) {
                throw new ParseSaveException("Empty Save File");
            }

            var versionLock = lines[0].Split(" ");
            if (versionLock[0] != VersionSpec || int.Parse(versionLock[1]) != SaveVersion) {
                // No Database Migration Yet
                throw new ParseSaveException("Invalid Version or Save File Not Exist");
            }

            foreach (var line in lines.Skip(1)) {
                var tokens = line.Split(" ");

                if (tokens.Length == 3 &&
                    int.TryParse(tokens[0], out var y) &&
                    int.TryParse(tokens[1], out var m) &&
                    int.TryParse(tokens[2], out var d) &&
                    m >= 1 && m <= 12 &&
                    d >= 1 && d <= 31
                ) {
                    WatchedDate.Add(new DateTime(y, m, d));
                }
            }
        } catch (ParseSaveException) {
            await SaveDatabase();
        }

        if (WatchedDate.Count > 0 && WatchedDate.Last() == Today) {
            for (var i = 0; i < Steven.VideoList.Length; i++) {
                Watched[i] = true;
            }

            IsAllWatched = true;
        }
    }

    public async Task SaveDatabase() {
        var content = $"{VersionSpec} {SaveVersion}\n";

        foreach (var date in WatchedDate ?? new List<DateTime>()) {
            content += $"{date.Year} {date.Month} {date.Day}\n";
        }

        var targetFile =
            await ApplicationData.Current.RoamingFolder.GetFileAsync(FileName);

        await FileIO.WriteTextAsync(targetFile, content);
    }
}
