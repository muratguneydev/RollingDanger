using System.Collections;
using NUnit.Framework;
using RollingDanger.RollingPlayer;
using Scripts;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class RollingPlayerBehaviourTests : ZenjectIntegrationTestFixture
{
	private const float Velocity = 10f;

	[UnityTest]
    public IEnumerator Should_GoRight_WhenRightArrowKeyDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Right);
		var originalX = setUp.RollingPlayerGameObject.transform.position.x;
		var originalZ = setUp.RollingPlayerGameObject.transform.position.z;
		//Act
		yield return new WaitForSeconds(0.1f);//Let it accelarate in the given direction for 0.1 second
		//Assert
		Assert.IsTrue(setUp.RollingPlayerGameObject.transform.position.x > originalX);
		Assert.AreEqual(originalZ, setUp.RollingPlayerGameObject.transform.position.z);
	}

	[UnityTest]
    public IEnumerator Should_GoLeft_WhenLeftArrowKeyDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Left);
		var originalX = setUp.RollingPlayerGameObject.transform.position.x;
		var originalZ = setUp.RollingPlayerGameObject.transform.position.z;
		//Act
		yield return new WaitForSeconds(0.1f);//Let it accelarate in the given direction for 0.1 second
		//Assert
		Assert.IsTrue(setUp.RollingPlayerGameObject.transform.position.x < originalX);
		Assert.AreEqual(setUp.RollingPlayerGameObject.transform.position.z, originalZ);
	}

	[UnityTest]
    public IEnumerator Should_GoForward_WhenForwardArrowKeyDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Forward);
		var originalX = setUp.RollingPlayerGameObject.transform.position.x;
		var originalZ = setUp.RollingPlayerGameObject.transform.position.z;
		//Act
		yield return new WaitForSeconds(0.1f);//Let it accelarate in the given direction for 0.1 second
		//Assert
		Assert.IsTrue(setUp.RollingPlayerGameObject.transform.position.z > originalZ);
		Assert.AreEqual(setUp.RollingPlayerGameObject.transform.position.x, originalX);
	}

	[UnityTest]
    public IEnumerator Should_GoBackward_WhenBackwardArrowKeyDown()
	{
		//Arrange
		var setUp = SetUp(KeyInputStub.Backward);
		var originalX = setUp.RollingPlayerGameObject.transform.position.x;
		var originalZ = setUp.RollingPlayerGameObject.transform.position.z;
		//Act
		yield return new WaitForSeconds(0.1f);//Let it accelarate in the given direction for 0.1 second
		//Assert
		Assert.IsTrue(setUp.RollingPlayerGameObject.transform.position.z < originalZ);
		Assert.AreEqual(setUp.RollingPlayerGameObject.transform.position.x, originalX);
	}

	private TestDependencyInstaller SetUp(KeyInput keyInput)
	{
		PreInstall();
		var setUp = new TestDependencyInstaller(Container, keyInput, new RollingPlayerSettings(Velocity, 0f));
		setUp.Install();
		PostInstall();

		return setUp;
	}
}
