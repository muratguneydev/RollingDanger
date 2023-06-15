using UnityEngine;

public static class TestRigidBody
{
	public static Rigidbody GetNew()
	{
		var gameObject = new GameObject();
		var rigidBody = gameObject.AddComponent<Rigidbody>();
		return rigidBody;
	}

	public static float GetX(this Rigidbody rigidBody)
		=> rigidBody.gameObject.transform.position.x;
}
