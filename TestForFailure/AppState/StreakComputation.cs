using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouAreAFailure.Classes;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestForFailure;

public partial class AppStateTest
{
    // Test related to Streak Computation

    [TestMethod]
    [Description("Test Streak Computation")]
    [DynamicData(nameof(StreakComputationTestCase), DynamicDataSourceType.Method)]
    public async Task StreakComputation(
        List<DateTime> TestData,
        int expectedCurrent,
        int expectedLongest
    )
    {
        var state = new AppState();
        await state.DatabaseReady;

        var stateYeeter = new PrivateObject(state);

        var today = new DateTime(2022, 03, 30);
        stateYeeter.SetField("Today", today);

        state.WatchedDate = TestData;

        Assert.AreEqual(state.ComputeCurrentStreak(), expectedCurrent);
        Assert.AreEqual(state.ComputeLongestStreak(), expectedLongest);
    }

    private static IEnumerable<object[]> StreakComputationTestCase()
    {
        yield return new object[]
        {
            new List<DateTime>()
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
            },
            2,
            4,
        };

        yield return new object[]
        {
            new List<DateTime>()
            {
                new DateTime(2022, 03, 28),
            },
            0,
            1,
        };

        yield return new object[]
        {
            new List<DateTime>()
            {
                new DateTime(2022, 03, 29),
            },
            1,
            1,
        };

        yield return new object[]
        {
            new List<DateTime>() {},
            0,
            0,
        };
    }
}
