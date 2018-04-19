using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts.Story;
using Assets.Scripts;

public class TestStory
{
    public IStoryService _storyService;
    public TestStory()
    {
        _storyService = new StoryService(new Repository());
    }

    [Test]
	public void TestStoryGet()
    {
        var letsTest = _storyService.Get(1);

        Assert.NotNull(letsTest);
    }

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator MyFirstTestWithEnumeratorPasses()
    {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
