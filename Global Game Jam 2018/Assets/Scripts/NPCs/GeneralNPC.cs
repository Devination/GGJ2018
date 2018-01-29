using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class GeneralNPC : MonoBehaviour {
	[SerializeField] GameObject deathFX;
	protected Animator animator;
	protected Rigidbody2D body;
	protected Player player;
	protected Spawner spawner;

	protected virtual void Start () {
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<Player>();
		spawner = FindObjectOfType<Spawner>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Sick")) {
			body.velocity = Vector2.zero;
			body.isKinematic = true;
			Die();
		}
	}

	//animator "Die" trigger will trigger this.
	public void PlayDeathFX () {
		Instantiate( deathFX, transform.position, Quaternion.identity );
		int deathNum = Random.Range( 0, spawner.deathClips.Length - 1 );
		GameObject soundObject = new GameObject();
		Instantiate( soundObject );
		AudioSource newSource = soundObject.AddComponent<AudioSource>();
		newSource.clip = spawner.deathClips[deathNum];
		newSource.Play();
		Destroy( gameObject );
	}

	virtual protected void Die () {
		animator.SetTrigger("Die");
		player.GetABitSadder();
	}
}
