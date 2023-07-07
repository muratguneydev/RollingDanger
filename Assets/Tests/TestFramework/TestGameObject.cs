using UnityEngine;

public class TestGameObject
{
	public static GameObject GetNew()
		=> new GameObject();

	public static GameObject GetNew(string name)
	{
		var gameObject = GetNew();
		gameObject.name = name;
		return gameObject;
	}
}