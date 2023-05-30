using UnityEngine;

namespace Scripts
{
	public class KeyInput
	{
		public virtual Vector2 GetNormalizedVector()
			=> new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}
}