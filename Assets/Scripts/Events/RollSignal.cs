using UnityEngine;

namespace RollingDanger.Events
{
	public class RollSignal
	{
		public RollSignal(Vector3 groundDirection) => RollDirection = groundDirection;

		public Vector3 RollDirection { get; }
	}
}