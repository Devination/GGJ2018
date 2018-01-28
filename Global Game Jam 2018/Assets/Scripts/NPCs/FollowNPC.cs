using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNPC : GeneralNPC {
	[SerializeField] float speed = 2;
	Transform player;

	protected override void Start () {
		base.Start();
		player = FindObjectOfType<Player>().transform;
	}

	void FixedUpdate () {
		Vector2 dirToPlayer = player.position - transform.position;
		body.velocity = dirToPlayer.normalized * speed;
	}
}
