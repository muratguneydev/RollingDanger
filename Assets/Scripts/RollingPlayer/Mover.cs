using Scripts;
using UnityEngine;

namespace RollingDanger.RollingPlayer
{
	public class Mover
	{
		private readonly KeyInput _keyInput;
		private readonly float _velocityUnitsPerFixedFrame;

		public Mover(KeyInput keyInput, float velocityUnitsPerFixedFrame)
		{
			_keyInput = keyInput;
			_velocityUnitsPerFixedFrame = velocityUnitsPerFixedFrame;
		}

		public Vector3 GetForce() => _keyInput.GetNormalizedVector() * _velocityUnitsPerFixedFrame;
	}
}