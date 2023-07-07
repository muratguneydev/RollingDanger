using UnityEngine;
using Zenject;

namespace Scripts.Camera
{
	public class CameraBehaviour : MonoBehaviour
	{
		private CameraMover _mover;

		[Inject]
		public virtual void Construct(CameraMover mover) => _mover = mover;

		// void Start()
		// {
		// 	var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		// 	_mover.InitializeDistanceToTarget();
		// }
		void LateUpdate() => _mover.Move(this.transform);
	}
}