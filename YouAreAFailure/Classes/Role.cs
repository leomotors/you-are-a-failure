#nullable enable

namespace YouAreAFailure.Classes;

public static class Role {
    public static readonly Tuple<int, string?>[] Roles = {
        new(0, null),
        new(1, "Newbie who just encountered Failure"),
        new(3, "Average Failure"),
        new(7, "No longer wandering in the deep mist"),
        new(14, "Fired Up"),
        new(28, "Emotional Damage"),
        new(365, "Super Asian"),
    };

    /// <summary>
    /// Return Value of Key which is maximum but not exceed <em>value</em>
    /// <br />
    /// Time Complexity is <em>O(logN)</em>
    /// </summary>
    public static int? LowerBound(Tuple<int, string?>[] items, int value) {
        var l = 0;
        var r = items.Length - 1;

        if (items.Length <= 0 || value < items[0].Item1) {
            return null;
        }

        while (l < r) {
            var mid = r - (r - l) / 2;
            if (value >= items[mid].Item1) {
                l = mid;
            } else {
                r = mid - 1;
            }
        }

        return l;
    }

    public static string GetRole(int streak, string prefix = "", string suffix = "") {
        var roleIndex = LowerBound(Roles, streak);

        var role = roleIndex is not null ? Roles[roleIndex ?? 0]?.Item2 : null;

        if (role is null) {
            return "";
        }

        return $"{prefix}{role}{suffix}";
    }
}
