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

	void PlayDeathFX () {
		Instantiate(deathFX, transform.position, Quaternion.identity);
	}

	void Die () {
		animator.SetTrigger("Die");
		Destroy(gameObject, 10);
	}
}
