using RollingDanger.Events;
using UnityEngine;

namespace Scripts.Camera
{
	public class CameraMover
	{
		private readonly CameraSettings _cameraSettings;
		private Vector3 _playerPosition;
		private Vector3 _cameraVelocity;
		private Vector3 _distanceToPlayer;

		public CameraMover(CameraSettings cameraSettings) => _cameraSettings = cameraSettings;

		public void Move(Transform cameraTransform)
		{
			if (_distanceToPlayer == default)
				_distanceToPlayer = cameraTransform.position - _playerPosition;
			MoveCameraAccordingToTheTarget(cameraTransform);
			PointCameraToTarget(cameraTransform);
		}

		public void OnPlayerMoved(RollingPlayerLocationSignal rollingPlayerLocationSignal)
			=> _playerPosition = rollingPlayerLocationSignal.Position;

		private void PointCameraToTarget(Transform cameraTransform) => cameraTransform.LookAt(_playerPosition);

		private void MoveCameraAccordingToTheTarget(Transform transform)
		{
			var playerPositionWithDistance = _playerPosition + _distanceToPlayer;//keep the same angle and distance to the player
			//Smooth damp will gradually change a vector towards a desired target over time.
			transform.position = Vector3.SmoothDamp(transform.position, playerPositionWithDistance, ref _cameraVelocity, _cameraSettings.SmoothTime);
		}
	}
}