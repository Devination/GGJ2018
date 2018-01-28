using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNPC : GeneralNPC {
	[SerializeField] float speed = 2;

	protected override void Start() {
		base.Start();
		InvokeRepeating( "DirectTowardsPlayer", 1.5f, 0.5f );
	}

	void DirectTowardsPlayer () {
		if( player != null ) {
			Vector2 dirToPlayer = player.transform.position - transform.position;
			body.velocity = dirToPlayer.normalized * speed;
		}
		else {
			body.velocity = Vector2.zero;
		}
	}

	protected override void Die () {
		spawner.DecreaseFollowCount();
		base.Die();
	}
}
