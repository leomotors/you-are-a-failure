global using System;
global using Microsoft.VisualStudio.TestTools.UnitTesting;

using YouAreAFailure.Classes;

#nullable enable

namespace TestForFailure;

/// <summary>
/// Testing for App State, making sure C# Codes behind the UI work as intended
/// </summary>
[TestClass]
public partial class AppStateTest
{
    [TestMethod]
    [Description("Test if Tester is working")]
    public void CheckUnitTester()
    {
        Assert.AreEqual(1 + 1, 2);
    }
}
