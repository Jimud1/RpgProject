using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts.Services;
using Assets.Scripts.Data;

public class TestStory
{
    public IStoryService _storyService;
    public IWeaponService _weaponService;
    public TestStory()
    {
        _storyService = new StoryService(new Repository());
        _weaponService = new WeaponService(new Repository());
    }

    [Test]
	public void TestStoryGet()
    {
        var letsTest = _storyService.Get(1);

        Assert.NotNull(letsTest);
    }

    [Test]
    public void TestWeaponsGet()
    {
        var test = _weaponService.Get(1);

        Assert.AreEqual(3, test.Attack);
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
