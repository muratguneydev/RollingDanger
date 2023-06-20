using RollingDanger.Events;
using UnityEngine;
using Zenject;

namespace Scripts
{
	public class UIEventHandler : MonoBehaviour
	{
		private IEventBus _eventBus;
		private KeyInput _keyInput;

		[Inject]
		public void Construct(IEventBus eventBus, KeyInput keyInput)
		{
			_eventBus = eventBus;
			_keyInput = keyInput;
		}

		// public void OnResetButtonClicked(GameObject gameOverScreen)
		// {
		// 	//_eventBus.Fire(new ResetButtonClickedUISignal(gameOverScreen));
		// 	Debug.Log("Game reset fired.");
		// }

		// void Start()
		// {
		// 	Debug.Log("UI Event handler start");
		// }

		void Update()
		{
			if (_keyInput.IsSpaceKeyDown)
			{
				_eventBus.Fire(new JumpSignal());
			}
		}
	}
}