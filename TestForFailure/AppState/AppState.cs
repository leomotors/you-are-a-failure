#nullable enable

namespace TestForFailure;

/// <summary>
/// Testing for App State, making sure C# Codes behind the UI work as intended
/// </summary>
[TestClass]
public partial class AppStateTest {
    [TestMethod]
    [Timeout(100)]
    [Description("Test if Tester is working")]
    public void CheckUnitTester() {
        Assert.AreEqual(2, 1 + 1);
    }
}
