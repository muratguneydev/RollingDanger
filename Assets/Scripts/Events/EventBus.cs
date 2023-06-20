using System;
using Zenject;

namespace RollingDanger.Events
{
	public class EventBus : IEventBus
	{
		private readonly SignalBus _signalBus;

		public EventBus(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Fire<TEvent>(TEvent @event)
		{
			_signalBus.Fire(@event);
		}

		public void Subscribe<TEvent>(Action<TEvent> callback)
		{
			//Usage: _eventBus.Subscribe<GoneThroughPipesSignal>(Increment);
			_signalBus.Subscribe(callback);
		}

		public void Unsubscribe<TEvent>(Action<TEvent> callback)
		{
			_signalBus.Unsubscribe(callback);
		}
	}
}