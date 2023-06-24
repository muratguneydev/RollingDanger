using System;
using RollingDanger.Events;

public class EventBusDummy : IEventBus
{
	public void Fire<TEvent>(TEvent @event)
	{
		
	}

	public void Subscribe<TEvent>(Action<TEvent> callback)
	{
		
	}

	public void Unsubscribe<TEvent>(Action<TEvent> callback)
	{
		
	}
}