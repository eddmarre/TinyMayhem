using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestableScripts;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHealthTest
{
    [Test]
    public void PlayerHealthTestSimplePasses()
    {
        Assert.AreEqual(Player.health, 100);
    }
}
