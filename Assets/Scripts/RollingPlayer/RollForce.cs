using UnityEngine;

namespace RollingDanger.RollingPlayer
{
	public partial class Mover
	{
		private class RollForce
		{
			private Vector3 _rollForce;
			private readonly float _rollVelocity;

			public RollForce(float rollVelocity) => _rollVelocity = rollVelocity;

			public Vector3 Force => _rollForce;

			public void Roll(Vector3 direction) => _rollForce = direction * _rollVelocity ;

			public void Reset() => _rollForce = Vector3.zero;
			
		}
	}
}