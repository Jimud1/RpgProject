﻿using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts.Story;
using Assets.Scripts;

public class MyFirstTest
{
    public IStoryService _storyService;
    public MyFirstTest()
    {
        _storyService = new StoryService(new Repository());
    }

    [Test]
	public void MyFirstTestSimplePasses()
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
