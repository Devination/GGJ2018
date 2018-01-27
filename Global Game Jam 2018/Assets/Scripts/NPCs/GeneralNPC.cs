using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GeneralNPC : MonoBehaviour {
	Animator animator;
	[SerializeField] GameObject deathFX;

	void Start () {
		animator = GetComponent<Animator>();
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
