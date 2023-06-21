using NUnit.Framework;
using RollingDanger.Events;
using RollingDanger.RollingPlayer;
using UnityEngine;

public class RollingPlayerMoverTests
{
	[Test]
	public void ShouldProvideCorrectForceForGivenDirection()
	{
		//Arrange
		var rollVelocity = 123f;
		var rollDirection = Vector3.up + Vector3.left;
		var mover = new Mover(new RollingPlayerSettings(rollVelocity, default));
		mover.OnRoll(new RollSignal(rollDirection));
		//Act & Assert
		var expectedForce = rollDirection * rollVelocity;
		Assert.AreEqual(expectedForce, mover.GetRollForce());
	}

	[Test]
	public void ShouldProvideCorrectForceForJump()
	{
		//Arrange
		var jumpForce = 123f;
		var mover = new Mover(new RollingPlayerSettings(default, jumpForce));
		mover.OnJump();
		//Act & Assert
		var expectedForce = Vector3.up * jumpForce;
		Assert.AreEqual(expectedForce, mover.GetJumpForce());
	}
}
