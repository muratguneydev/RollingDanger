using UnityEngine;

namespace RollingDanger.RollingPlayer
{
	public partial class Mover
	{
		private class JumpForce
		{
			private readonly Vector3 _upJumpForce;
			private readonly Vector3 _zeroJumpForce;
			private Vector3 _jumpForce;

			public JumpForce(float jumpVelocity)
			{
				_upJumpForce = Vector3.up * jumpVelocity;
				_zeroJumpForce = Vector3.zero;
				_jumpForce = _zeroJumpForce;
			}

			public Vector3 Force => _jumpForce;

			public void Jump() => _jumpForce = _upJumpForce;

			public void Reset() => _jumpForce = _zeroJumpForce;
		}
	}
}