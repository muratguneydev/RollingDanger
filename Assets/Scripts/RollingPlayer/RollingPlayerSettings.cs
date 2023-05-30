using System;

namespace RollingDanger.RollingPlayer
{
	[Serializable]
	public class RollingPlayerSettings
	{
		public RollingPlayerSettings(float velocity, float jumpForce)
		{
			Velocity = velocity;
			JumpForce = jumpForce;
		}

		public float Velocity = 17.5f;

		public float JumpForce = 120;
	}
}