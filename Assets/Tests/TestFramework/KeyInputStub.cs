using Scripts;
using UnityEngine;
public class KeyInputStub : KeyInput
{
	private readonly Vector3 _result;
	private readonly bool _isSpaceKeyDown;

	public KeyInputStub(Vector3 result)
	{
		_result = result.normalized;
	}

	public KeyInputStub(bool isSpaceKeyDown)
	{
		_isSpaceKeyDown = isSpaceKeyDown;
	}

	public static KeyInput Space => new KeyInputStub(true);
	public static KeyInput Right => new KeyInputStub(Vector3.right);
	public static KeyInput Left => new KeyInputStub(Vector3.left);
	public static KeyInput Up => new KeyInputStub(Vector3.up);
	public static KeyInput Down => new KeyInputStub(Vector3.down);
	public static KeyInput Forward => new KeyInputStub(Vector3.forward);
	public static KeyInput Backward => new KeyInputStub(Vector3.back);
	public static KeyInput None => new KeyInputStub(Vector3.zero);

	public static KeyInput UpRight => new KeyInputStub(Vector3.up + Vector3.right);
	public static KeyInput DownRight => new KeyInputStub(Vector3.down + Vector3.right);
	public static KeyInput UpLeft => new KeyInputStub(Vector3.up + Vector3.left);
	public static KeyInput DownLeft => new KeyInputStub(Vector3.down + Vector3.left);

	public override bool IsSpaceKeyDown => _isSpaceKeyDown;

	public override Vector3 GetNormalizedVector()
	{
		return _result;
	}
}
