using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;

using YouAreAFailure.Classes;

#nullable enable

namespace TestForFailure;

public partial class AppStateTest {
    // Tests related to Database

    private static readonly string SaveHeader =
    $"{AppState.VersionSpec} {AppState.SaveVersion}";
}

public partial class AppStateTest {
    [TestMethod]
    [Description("Test if loader (Loading Database) is working as intended")]
    [DynamicData(nameof(DatabaseLoadingTestCase), DynamicDataSourceType.Method)]
    public async Task DatabaseLoading(string saveData, List<DateTime> expected) {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        await FileIO.WriteTextAsync(sf, saveData);

        var state = new AppState();
        await state.DatabaseReady;

        CollectionAssert.AreEquivalent(expected, state.WatchedDate);
    }

    private static IEnumerable<object[]> DatabaseLoadingTestCase() {
        yield return new object[]
        {
            @$"{SaveHeader}
2022 3 7
2022 3 9
illegal strings, also below empty new line, hehe

",
            new List<DateTime>()
            {
                new DateTime(2022, 3, 7),
                new DateTime(2022, 3, 9),
            }
        };

        yield return new object[]
        {
            @$"invalid header lmao
2022 3 7
2022 3 9
2022 3 10",
            new List<DateTime>() {}
        };
    }
}

public partial class AppStateTest {
    [TestMethod]
    [Description("Test if database saves correctly when all video is watched")]
    public async Task DatabaseSaverToday() {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        await FileIO.WriteTextAsync(sf, "");

        var state = new AppState();
        await state.DatabaseReady;

        var now = DateTime.Now;
        var today = new DateTime(now.Year, now.Month, now.Day);

        foreach (var video in Steven.VideoList) {
            state.AddWatched(video.FileName);
        }

        Assert.IsTrue(state.IsAllWatched);

        CollectionAssert.AreEquivalent(
             new List<DateTime>() { today }, state.WatchedDate
        );

        await state.DatabaseReady;

        var wrote = await FileIO.ReadTextAsync(sf);

        Assert.AreEqual(
            $"{SaveHeader}\n{today.Year} {today.Month} {today.Day}",
            wrote.Trim()
        );
    }

    [TestMethod]
    [Description("Test if database save as intended with given data")]
    [DynamicData(nameof(DatabaseSaverTestCase), DynamicDataSourceType.Method,
        DynamicDataDisplayName = nameof(DatabaseSaverCaseName))]
    public async Task DatabaseSaver(
        List<DateTime> testData,
        string expected,
        object? _ = null) {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        var state = new AppState();
        await state.DatabaseReady;

        state.WatchedDate = testData;
        await state.SaveDatabase();

        var wrote = await FileIO.ReadTextAsync(sf);

        Assert.AreEqual(expected.Replace("\r\n", "\n").Trim(), wrote.Trim());
    }

    private static IEnumerable<object[]> DatabaseSaverTestCase() {
        yield return new object[]
        {
            new List<DateTime>()
            {
                new DateTime(2022, 3, 4),
                new DateTime(2022, 3, 5),
                new DateTime(2022, 3, 7),
                new DateTime(2024, 12, 31),
            },
            @$"{SaveHeader}
2022 3 4
2022 3 5
2022 3 7
2024 12 31
"
        };

        yield return new object[]
        {
            new List<DateTime>(),
            $"{SaveHeader}\n",
        };

        var notToday = new DateTime(1980, 1, 1);
        List<DateTime> dates = new();
        var longBoi = $"{SaveHeader}\n";
        var random = new Random();

        for (var i = 0; i < 4000; i++) {
            notToday = notToday.AddDays(random.Next(3) + 1);
            dates.Add(notToday);
            longBoi += $"{notToday.Year} {notToday.Month} {notToday.Day}\n";
        }

        yield return new object[] { dates, longBoi, "Very Long Case (4000 Days)" };
    }

    public static string DatabaseSaverCaseName(MethodInfo _, object[] values) {
        var overrideName = values.Length > 2 ? values[2] as string : null;

        return overrideName ?? (values[1] as string)!;
    }
}
