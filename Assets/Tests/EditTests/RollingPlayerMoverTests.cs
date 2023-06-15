using System.Linq;
using System.Reflection;
using NUnit.Framework;
using RollingDanger.RollingPlayer;
using Scripts;

public class RollingPlayerMoverTests
{
	[Test]
	public void ShouldProvideCorrectForceForEveryDirection()
	{
		var type = typeof(KeyInputStub);
		foreach (var p in type.GetProperties(BindingFlags.Public | BindingFlags.Static)
							  .Where(property => property.PropertyType == typeof(KeyInput)))
		{
			VerifyForceForDirection(p.GetValue(null, null) as KeyInput);
		}
	}

	private static void VerifyForceForDirection(KeyInput keyInput)
	{
		//Arrange
		var velocity = 123f;
		var mover = new Mover(keyInput, velocity);
		//Act & Assert
		var expectedForce = keyInput.GetNormalizedVector() * velocity;
		Assert.AreEqual(expectedForce, mover.GetForce());
	}
}
