using Scripts;
using UnityEngine;
using Zenject;

namespace RollingDanger.RollingPlayer
{
	[RequireComponent(typeof(Rigidbody))]
	public class RollingPlayerBehaviour : MonoBehaviour
	{
		private Rigidbody _rigidBody;
		private KeyInput _keyInput;

		[Inject]
		public virtual void Construct(KeyInput keyInput)
		{
			_keyInput = keyInput;
		}

		// Start is called before the first frame update
		void Start()
		{
			_rigidBody = GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		// void Update()
		// {

		// }

		void FixedUpdate()
		{

		}
	}
}