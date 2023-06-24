using RollingDanger.Events;
using UnityEngine;

namespace RollingDanger.RollingPlayer
{
	public class Mover
	{
		private readonly JumpForce _jumpForce;
		private readonly RollForce _rollForce;
		private readonly IEventBus _eventBus;

		public Mover(IEventBus eventBus, RollingPlayerSettings rollingPlayerSettings)
		{
			_jumpForce = new JumpForce(rollingPlayerSettings.JumpVelocity);
			_rollForce = new RollForce(rollingPlayerSettings.Velocity);
			_eventBus = eventBus;
		}

		public void OnJump() => _jumpForce.Jump();

		public void OnRoll(RollSignal rollSignal) => _rollForce.Roll(rollSignal.RollDirection);

		public void Move(Rigidbody rigidBody)
		{
			var moveForce = GetMoveForce();
			rigidBody.AddForce(moveForce.RollForce.Force, ForceMode.Acceleration);
			//Note:We can implement Raycasting to see if we are touching the ground to avoid jump spamming i.e. continous jumps.
			rigidBody.AddForce(moveForce.JumpForce.Force, ForceMode.Impulse);

			_eventBus.Fire(new RollingPlayerLocationSignal(rigidBody.transform.position));
		}

		private MoveForce GetMoveForce()
		{
			var moveForce = new MoveForce(_rollForce, _jumpForce);
			_rollForce.Reset();
			_jumpForce.Reset();
			return moveForce;
		}
	}
}