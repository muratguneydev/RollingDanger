using UnityEngine;
using Zenject;

namespace RollingDanger.RollingPlayer
{
	[RequireComponent(typeof(Rigidbody))]
	public class RollingPlayerBehaviour : MonoBehaviour
	{
		private Rigidbody _rigidBody;
		private Mover _mover;

		[Inject]
		public virtual void Construct(Mover mover)
		{
			_mover = mover;
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
			_rigidBody.AddForce(_mover.GetForce(), ForceMode.Acceleration);
			//Debug.Log($"Current x:{_rigidBody.transform.position.x}");
		}
	}
}