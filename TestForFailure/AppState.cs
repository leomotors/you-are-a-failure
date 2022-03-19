using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouAreAFailure.Classes;

using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace TestForFailure;

[TestClass]
public class AppStateTest
{
    [TestMethod]
    [Description("Test if Tester is working")]
    public void CheckUnitTester()
    {
        Assert.AreEqual(1 + 1, 2);
    }

    [TestMethod]
    [Description("Test Streak Computation")]
    public async Task StreakComputation()
    {
        var state = new AppState();
        await state.DatabaseReady;

        var stateYeeter = new PrivateObject(state);

        var today = new DateTime(2022, 03, 30);
        stateYeeter.SetField("Today", today);

        // Test Case 1
        state.WatchedDate = new()
        {
            new DateTime(2022, 03, 10),
            new DateTime(2022, 03, 11),
            new DateTime(2022, 03, 12),
            new DateTime(2022, 03, 13),
            new DateTime(2022, 03, 15),
            new DateTime(2022, 03, 16),
            new DateTime(2022, 03, 17),
            new DateTime(2022, 03, 28),
            new DateTime(2022, 03, 29),
        };

        Assert.AreEqual(state.ComputeLongestStreak(), 4);
        Assert.AreEqual(state.ComputeCurrentStreak(), 2);

        // Test Case 2
        state.WatchedDate = new()
        {
            new DateTime(2022, 03, 28),
        };

        Assert.AreEqual(state.ComputeLongestStreak(), 1);
        Assert.AreEqual(state.ComputeCurrentStreak(), 0);

        // Test Case 3
        state.WatchedDate = new();

        Assert.AreEqual(state.ComputeLongestStreak(), 0);
        Assert.AreEqual(state.ComputeCurrentStreak(), 0);
    }

    private readonly string SaveHeader =
    $"{AppState.VersionSpec} {AppState.SaveVersion}";

    [TestMethod]
    [Description("Test if loader (Loading Database) is working as intended")]
    public async Task DatabaseLoading()
    {
        var sf = await ApplicationData.Current.RoamingFolder.CreateFileAsync(
            AppState.FileName, CreationCollisionOption.OpenIfExists
        );

        var data = @$"{SaveHeader}
2022 3 7
2022 3 9
illegal strings, also below empty new line, hehe

";

        await FileIO.WriteTextAsync(sf, data);

        var state = new AppState();
        await state.DatabaseReady;

        CollectionAssert.AreEquivalent(
            state.WatchedDate,
            new List<DateTime>()
            {
                new DateTime(2022, 3, 7),
                new DateTime(2022, 3, 9),
            }
        );
    }

    [TestMethod]
    [Description("Test if database saves correctly when all video is watched")]
    public async Task DatabaseSaver()
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
}
