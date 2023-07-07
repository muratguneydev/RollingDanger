using System;
using UnityEngine;

namespace Scripts.Camera
{
	[Serializable]
	public class CameraSettings
	{
		public CameraSettings(Vector3 distanceToPlayer, float smoothTime)
		{
			DistanceToPlayer = distanceToPlayer;
			SmoothTime = smoothTime;
		}

		public Vector3 DistanceToPlayer = default;
		public float SmoothTime = 0.3f;
	}
}