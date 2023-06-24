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
			//Note:Firing events from Update may not be the best approach.
			//Debug.Log($"_keyInput.IsSpaceKeyDown:{_keyInput.IsSpaceKeyDown}");
			if (_keyInput.IsSpaceKeyDown)
			{
				_eventBus.Fire(new JumpSignal());
			}

			var rollDirection = _keyInput.GetNormalizedVector();
			_eventBus.Fire(new RollSignal(rollDirection));
		}
	}
}