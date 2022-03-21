using YouAreAFailure.Classes;

#nullable enable

namespace TestForFailure;

public partial class AppStateTest {
    // Test related to Streak Computation

    private readonly DateTime todayDefault = new(2022, 03, 30);

    [TestMethod]
    [Timeout(100)]
    [Description("Test Streak Computation")]
    [DynamicData(nameof(StreakComputationTestCase), DynamicDataSourceType.Method,
        DynamicDataDisplayName = nameof(StreakComputationCaseName))]
    public async Task StreakComputation(
        List<DateTime> TestData,
        int expectedCurrent,
        int expectedLongest,
        int _,
        DateTime? today = null) {
        var state = new AppState();
        await state.DatabaseReady;

        var stateYeeter = new PrivateObject(state);

        today ??= todayDefault;
        stateYeeter.SetField("Today", today);

        state.WatchedDate = TestData;

        Assert.AreEqual(expectedCurrent, state.ComputeCurrentStreak());
        Assert.AreEqual(expectedLongest, state.ComputeLongestStreak());
    }

    private static IEnumerable<object[]> StreakComputationTestCase() {
        // Test 1
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
            1,
        };

        // Test 2
        yield return new object[]
        {
            new List<DateTime>()
            {
                new DateTime(2022, 03, 28),
            },
            0,
            1,
            2,
        };

        // Test 3
        yield return new object[]
        {
            new List<DateTime>()
            {
                new DateTime(2022, 03, 29),
            },
            1,
            1,
            3,
        };

        // Test 4
        yield return new object[]
        {
            new List<DateTime>() {},
            0,
            0,
            4,
        };

        // Test 5
        yield return new object[]
        {
            new List<DateTime>()
            {
                new DateTime(2022, 03, 24),
                new DateTime(2022, 03, 25),
                new DateTime(2022, 03, 26),
                new DateTime(2022, 03, 27),
                new DateTime(2022, 03, 28),
                new DateTime(2022, 03, 29),
                new DateTime(2022, 03, 30),
            },
            7,
            7,
            5,
        };

        // Test 6

        List<DateTime> dates = new();
        var notToday = new DateTime(1980, 1, 3);

        for (var i = 0; i < 10000; i++) {
            dates.Add(notToday.AddDays(2 * i));
        }

        yield return new object[] { dates, 0, 1, 6, new DateTime(9000, 1, 1) };
    }

    public static string StreakComputationCaseName(MethodInfo _, object[] values) {
        var expectedCurrent = values[1] as int?;
        var expectedLongest = values[2] as int?;
        var tcid = values[3] as int?;

        return $"Test #{tcid}: Current = {expectedCurrent}, Longest = {expectedLongest}";
    }
}
