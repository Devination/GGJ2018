using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNPC : GeneralNPC {
	[SerializeField] float speed = 2;

	void FixedUpdate () {
		Vector2 dirToPlayer = player.transform.position - transform.position;
		body.velocity = dirToPlayer.normalized * speed;
	}
}
