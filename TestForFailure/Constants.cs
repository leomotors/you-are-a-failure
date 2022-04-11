namespace TestForFailure;

using System.Linq;

using YouAreAFailure.Classes;

#nullable enable

/// <summary>
/// Test to make sure I didn't messed up <see cref="Constants">Constants</see> class.
/// <br />
/// If this test fail, I'm more than a failure!
/// </summary>
[TestClass]
public class ConstantsTest {
    [TestMethod]
    [Timeout(100)]
    [Description("Test if I messed up Store Link")]
    public void TestStoreLink() {
        var StoreLinkID = Constants.MSStoreLink.Split("/").Last();
        var ReviewLinkID = Constants.MSStoreReviewLink.Split("=").Last();

        Assert.AreEqual(StoreLinkID, ReviewLinkID);
    }
}
