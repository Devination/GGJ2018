﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class GeneralNPC : MonoBehaviour {
	[SerializeField] GameObject deathFX;
	Animator animator;
	protected Rigidbody2D body;

	protected virtual void Start () {
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Sick")) {
			Die();
		}
	}

	//animator "Die" trigger will trigger this.
	public void PlayDeathFX () {
		Instantiate(deathFX, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void Die () {
		animator.SetTrigger("Die");
	}
}
