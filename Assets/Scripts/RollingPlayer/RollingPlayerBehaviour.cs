using System;
using System.Collections.Generic;
using RollingDanger.Events;
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
		public virtual void Construct(Mover mover) => _mover = mover;

		void Start() => _rigidBody = GetComponent<Rigidbody>();
		

		// Update is called once per frame
		// void Update()
		// {
		// 	Debug.Log("RollingPlayerBehaviour update");

		// }

		void FixedUpdate()
		{
			_mover.Move(_rigidBody);

			// var moveForce = _mover.GetMoveForce();
			// _rigidBody.AddForce(moveForce.RollForce.Force, ForceMode.Acceleration);
			// //Note:We can implement Raycasting to see if we are touching the ground to avoid jump spamming i.e. continous jumps.
			// _rigidBody.AddForce(moveForce.JumpForce.Force, ForceMode.Impulse);//this.gameObject.transform.position
		}
	}
}