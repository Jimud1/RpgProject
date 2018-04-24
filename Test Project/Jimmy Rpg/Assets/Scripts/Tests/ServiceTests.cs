using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts.Services;
using Assets.Scripts.Data;
using Assets.Scripts.Services.Monster;

public class ServiceTests
{
    public IStoryService _storyService;
    public IWeaponService _weaponService;
    public IQuestService _questService;
    public IArmourService _armourService;
    public IMonsterService _monsterService;
    public ServiceTests()
    {
        var repo = new Repository();
        _storyService = new StoryService(repo);
        _weaponService = new WeaponService(repo);
        _questService = new QuestService(repo);
        _armourService = new ArmourService(repo);
        _monsterService = new MonsterService(repo);
    }

    [Test]
    public void TestArmourService()
    {
        var test = _armourService.Get(1);
        Assert.NotNull(test);
        Assert.AreEqual(5, test.Defense);
    }

    [Test]
    public void TestQuestService()
    {
        var test = _questService.Get(1);
        Assert.NotNull(test);
        Assert.AreEqual(false, test.Completed);
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

    [Test]
    public void TestMonsterGet()
    {
        var test = _monsterService.Get(1);
        Assert.AreEqual(5, test.Statistics.Strength);
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
