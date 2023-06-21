using RollingDanger.Events;
using UnityEngine;

namespace RollingDanger.RollingPlayer
{
	public partial class Mover
	{
		private readonly JumpForce _jumpForce;
		private readonly RollForce _rollForce;

		public Mover(RollingPlayerSettings rollingPlayerSettings)
		{
			_jumpForce = new JumpForce(rollingPlayerSettings.JumpVelocity);
			_rollForce = new RollForce(rollingPlayerSettings.Velocity);
		}

		public virtual Vector3 GetRollForce()
		{
			var rollForce = _rollForce.Force;
			_rollForce.Reset();
			return rollForce;
		}

		public virtual Vector3 GetJumpForce()
		{
			var force = _jumpForce.Force;
			_jumpForce.Reset();
			return force;
		}

		public void OnJump() => _jumpForce.Jump();

		public void OnRoll(RollSignal rollSignal) => _rollForce.Roll(rollSignal.RollDirection);
	}
}