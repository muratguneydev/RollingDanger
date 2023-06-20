using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RollingDanger.RollingPlayer
{
	[RequireComponent(typeof(Rigidbody))]
	public class RollingPlayerBehaviour : MonoBehaviour
	{
		private Rigidbody _rigidBody;
		private Mover _mover;
	private List<Action> _actions = new List<Action>();


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
		// 	Debug.Log("RollingPlayerBehaviour update");

		// }

		void FixedUpdate()
		{
			_rigidBody.AddForce(_mover.GetGroundForce(), ForceMode.Acceleration);
			_rigidBody.AddForce(_mover.GetJumpForce(), ForceMode.Impulse);
			//Debug.Log($"Current x:{_rigidBody.transform.position.x}");
		}
	}
}