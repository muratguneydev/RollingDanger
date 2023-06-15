using UnityEngine;

namespace Scripts
{
	public class KeyInput
	{
		public virtual Vector3 GetNormalizedVector()
			=> new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
	}
}