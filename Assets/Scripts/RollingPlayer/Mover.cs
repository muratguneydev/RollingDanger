using Scripts;
using UnityEngine;

namespace RollingDanger.RollingPlayer
{
	public class Mover
	{
		private readonly KeyInput _keyInput;
		private readonly RollingPlayerSettings _rollingPlayerSettings;
		//private readonly float _velocityUnitsPerFixedFrame;
		private Vector3 _jumpForce;

		public Mover(KeyInput keyInput, RollingPlayerSettings rollingPlayerSettings)
		//float velocityUnitsPerFixedFrame)
		{
			_keyInput = keyInput;
			_rollingPlayerSettings = rollingPlayerSettings;
			//_velocityUnitsPerFixedFrame = velocityUnitsPerFixedFrame;
		}

		public virtual Vector3 GetGroundForce()
		{
			var groundForce = _keyInput.GetNormalizedVector() * _rollingPlayerSettings.Velocity;
			return groundForce;
		}

		public virtual Vector3 GetJumpForce()
		{
			//Debug.Log($"Jump force:{_jumpForce}");
			var force = _jumpForce;
			ResetJumpForce();
			return force;
		}

		private void ResetJumpForce()
		{
			_jumpForce = Vector3.zero;
		}

		public void OnJump()
		{
			_jumpForce = Vector3.up * _rollingPlayerSettings.JumpForce;
		}
	}
}