namespace TestForFailure;

using YouAreAFailure.Classes;

#nullable enable

/// <summary>
/// Test for <see cref="Role">Classes.Role</see>
/// </summary>
[TestClass]
public class RoleTest {
    [TestMethod]
    [Timeout(100)]
    [Description("Test if Lower Bound Function works")]
    [DynamicData(nameof(LowerBoundTestCase), DynamicDataSourceType.Method,
        DynamicDataDisplayName = nameof(LowerBoundCaseName))]
    public void LowerBoundTest(
        Tuple<int, string?>[] items,
        Tuple<int, int?>[] tests,
        object? _ = null
    ) {

        foreach (var test in tests) {
            Assert.AreEqual(test.Item2, Role.LowerBound(items, test.Item1));
        }
    }

    private static IEnumerable<object[]> LowerBoundTestCase() {
        yield return new object[] {
            new Tuple<int, string?>[] {
                new(0, null),
                new(4, null),
                new(7, null),
                new(15, null),
                new(16, null),
                new(17, null),
                new(22, null),
            },
            new Tuple<int, int?>[] {
                new(3, 0),
                new(7, 2),
                new(14, 2),
                new(16, 4),
                new(69420, 6),
                new(-1, null),
            },
            "Normal Case",
        };

        yield return new object[] {
            new Tuple<int, string?>[] {},
            new Tuple<int, int?>[] {
                new(69, null),
                new(420, null),
            },
            "Edgy Cases that never need to consider (Zero Role)",
        };

        yield return new object[] {
            new Tuple<int, string?>[] { new(69, null)},
            new Tuple<int, int?>[] {
                new(50, null),
                new(69, 0),
                new(420, 0),
            },
            "Only One Role Exists",
        };
    }

    public static string LowerBoundCaseName(MethodInfo _, object[] values) {
        var randomName =
            $"{(values[0] as object[])?.Length}-{(values[1] as object[])?.Length}";

        return values.Length > 2 ? (values[2] as string) ?? randomName : randomName;
    }

    [TestMethod]
    [Timeout(100)]
    [Description("Test GetRole Functions that will return string")]
    public void GetRoleTest() {
        const string prefix = "bruh";
        var tests = new Tuple<int, string>[]  {
            new(0, ""),
            new(1, $"{prefix}Newbie who just encountered Failure"),
            new(17, $"{prefix}Fired Up"),
            new(333, $"{prefix}Emotional Damage"),
            new(999, $"{prefix}Super Asian"),
        };

        foreach (var test in tests) {
            Assert.AreEqual(test.Item2, Role.GetRole(test.Item1, prefix));
        }
    }
}
