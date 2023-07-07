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

		[Inject]
		public virtual void Construct(Mover mover) => _mover = mover;

		void Start() => _rigidBody = GetComponent<Rigidbody>();

		void FixedUpdate() => _mover.Move(_rigidBody);
	}
}