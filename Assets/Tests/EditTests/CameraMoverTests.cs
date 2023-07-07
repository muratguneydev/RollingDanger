using NUnit.Framework;
using RollingDanger.Events;
using Scripts.Camera;
using UnityEngine;

public class CameraMoverTests
{
	[Test]
	public void ShouldFollowPlayer()
	{
		//Arrange
		var cameraVelocity = Vector3.zero;
		var smoothTime = 123f;
		var cameraSettings = new CameraSettings(default, smoothTime);
		var cameraMover = new CameraMover(cameraSettings);
		var playerInitialPosition = new Vector3(1, 2, 3);
		MovePlayerAndSignal(cameraMover, playerInitialPosition);

		var camera = TestGameObject.GetNew();
		var initialCameraPosition = new Vector3(100, 200, 300);
		camera.transform.position = initialCameraPosition;

		var distanceToPlayer = initialCameraPosition - playerInitialPosition;
		//Act
		cameraMover.Move(camera.transform);
		//Assert after first player and camera move
		var playerPositionWithDistance = playerInitialPosition + distanceToPlayer;
		var expectedCameraPosition = Vector3.SmoothDamp(initialCameraPosition, playerPositionWithDistance, ref cameraVelocity, smoothTime);
		Assert.AreEqual(expectedCameraPosition, camera.transform.position);

		//Assert after a new player and camera move
		//Arrange
		var playerNewPosition = new Vector3(10, 20, 30);
		MovePlayerAndSignal(cameraMover, playerNewPosition);
		//Act
		cameraMover.Move(camera.transform);
		//Assert after second move
		playerPositionWithDistance = playerNewPosition + distanceToPlayer;
		expectedCameraPosition = Vector3.SmoothDamp(expectedCameraPosition, playerPositionWithDistance, ref cameraVelocity, smoothTime);
		Assert.AreEqual(expectedCameraPosition, camera.transform.position);
	}

	private static void MovePlayerAndSignal(CameraMover mover, Vector3 playerNewLocation)
	{
		var playerMovedSignal = new RollingPlayerLocationSignal(playerNewLocation);
		mover.OnPlayerMoved(playerMovedSignal);
	}
}