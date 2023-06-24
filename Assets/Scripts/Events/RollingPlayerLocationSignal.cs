using UnityEngine;

namespace RollingDanger.Events
{
	public class RollingPlayerLocationSignal
	{
		public RollingPlayerLocationSignal(Vector3 position)
		{
			Position = position;
		}

		public Vector3 Position { get; }
	}
}