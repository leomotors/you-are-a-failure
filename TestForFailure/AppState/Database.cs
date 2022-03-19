using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouAreAFailure.Classes;

using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace TestForFailure;

public partial class AppStateTest
{
    // Tests related to Database

    private static readonly string SaveHeader =
    $"{AppState.VersionSpec} {AppState.SaveVersion}";
}

public partial class AppStateTest
{
    [TestMethod]
    [Description("Test if loader (Loading Database) is working as intended")]
    [DynamicData(nameof(DatabaseLoadingTestCase), DynamicDataSourceType.Method)]
    public async Task DatabaseLoading(string saveData, List<DateTime> expected)
    {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        await FileIO.WriteTextAsync(sf, saveData);

        var state = new AppState();
        await state.DatabaseReady;

        CollectionAssert.AreEquivalent(state.WatchedDate, expected);
    }

    private static IEnumerable<object[]> DatabaseLoadingTestCase()
    {
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

public partial class AppStateTest
{
    [TestMethod]
    [Description("Test if database saves correctly when all video is watched")]
    public async Task DatabaseSaverToday()
    {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        await FileIO.WriteTextAsync(sf, "");

        var state = new AppState();
        await state.DatabaseReady;

        var now = DateTime.Now;
        var today = new DateTime(now.Year, now.Month, now.Day);

        foreach (var video in Steven.VideoList)
        {
            state.AddWatched(video.FileName);
        }

        Assert.IsTrue(state.IsAllWatched);

        CollectionAssert.AreEquivalent(
            state.WatchedDate, new List<DateTime>() { today }
        );

        await state.DatabaseReady;

        var wrote = await FileIO.ReadTextAsync(sf);

        Assert.AreEqual(
            wrote.Trim(),
            $"{SaveHeader}\n{today.Year} {today.Month} {today.Day}"
        );
    }

    [TestMethod]
    [Description("Test if database save as intended with given data")]
    [DynamicData(nameof(DatabaseSaverTestCase), DynamicDataSourceType.Method)]
    public async Task DatabaseSaver(List<DateTime> testData, string expected)
    {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        var state = new AppState();
        await state.DatabaseReady;

        state.WatchedDate = testData;
        await state.SaveDatabase();

        var wrote = await FileIO.ReadTextAsync(sf);

        Assert.AreEqual(wrote.Trim(), expected.Replace("\r\n", "\n").Trim());
    }

    private static IEnumerable<object[]> DatabaseSaverTestCase()
    {
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
    }
}
