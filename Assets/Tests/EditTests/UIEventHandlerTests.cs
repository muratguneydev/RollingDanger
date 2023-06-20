using NUnit.Framework;
using RollingDanger.Events;
using Scripts;

public class UIEventHandlerTests
{
	[Test]
	public void ShouldFireJumpSignalWhenSpaceKeyDown()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<JumpSignal>();
		var uiEventHandlerWrapper = new MonoReflector<UIEventHandler>();
		uiEventHandlerWrapper.MonoBehaviour.Construct(eventBusSpy, KeyInputStub.Space);
		//Act
		uiEventHandlerWrapper.Update();
		//Assert
		var (isFired, signal) = eventBusSpy.IsExpectedEventFired();
		Assert.IsTrue(isFired);
	}
}