using NUnit.Framework;
using RollingDanger.Events;
using RollingDanger.RollingPlayer;
using UnityEngine;

public class RollingPlayerMoverTests
{
	[Test]
	public void ShouldProvideCorrectRollForceForGivenDirection()
	{
		//Arrange
		var rollVelocity = 123f;
		var rollDirection = Vector3.up + Vector3.left;
		var mover = new Mover(new EventBusDummy(), new RollingPlayerSettings(rollVelocity, default));
		mover.OnRoll(new RollSignal(rollDirection));
		var rigidBody = TestRigidBody.GetNew();
		var rigidBodyExpected = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var expectedRollForce = rollDirection * rollVelocity;
		rigidBodyExpected.AddForce(expectedRollForce, ForceMode.Acceleration);
		Assert.AreEqual(rigidBodyExpected.position, rigidBody.position);
	}

	[Test]
	public void ShouldProvideCorrectForceForJump()
	{
		//Arrange
		var jumpForce = 123f;
		var mover = new Mover(new EventBusDummy(), new RollingPlayerSettings(default, jumpForce));
		mover.OnJump();
		var rigidBody = TestRigidBody.GetNew();
		var rigidBodyExpected = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var expectedJumpForce = Vector3.up * jumpForce;
		rigidBodyExpected.AddForce(expectedJumpForce, ForceMode.Impulse);
		Assert.AreEqual(rigidBodyExpected.position, rigidBody.position);
	}

	[Test]
	public void ShouldFireRollingPlayerLocationSignalWhenMoved()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<RollingPlayerLocationSignal>();
		var mover = new Mover(eventBusSpy, new RollingPlayerSettings(default, default));
		var rigidBody = TestRigidBody.GetNew();
		//Act
		mover.Move(rigidBody);
		//Assert
		var (isFired, signal) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
		Assert.AreEqual(rigidBody.position, signal.Position);
	}
}
