using System;

namespace RollingDanger.RollingPlayer
{
	[Serializable]
	public class RollingPlayerSettings
	{
		public RollingPlayerSettings(float velocity, float jumpForce)
		{
			Velocity = velocity;
			JumpVelocity = jumpForce;
		}

		public float Velocity = 17.5f;

		public float JumpVelocity = 10;
	}
}