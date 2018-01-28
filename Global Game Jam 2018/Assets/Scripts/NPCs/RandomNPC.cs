using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPC : GeneralNPC {
	[SerializeField] float speed = 2;
	[SerializeField] float moveTime = 1;
	[SerializeField] float delayTime = 1;
	[SerializeField] LayerMask npcMask;

	Vector2[] directions = new Vector2[] {Vector2.up , Vector2.down, Vector2.left, Vector2.right};

	protected override void Start () {
		base.Start();
		StartCoroutine(Movement());
	}

	IEnumerator Movement() {
		yield return new WaitForSeconds( delayTime );
		while (true) {
			yield return new WaitForSeconds(delayTime);
			animator.SetBool("Walking", true);
			Vector2 direction = GetOpenDirection();
			body.AddForce(direction * speed, ForceMode2D.Impulse);
			yield return new WaitForSeconds(moveTime);
			animator.SetBool("Walking", false);
			body.velocity = Vector2.zero;
		}
	}

	Vector2 GetOpenDirection() {
		Vector2 position = transform.position;
		Vector2 direction = directions[Random.Range(0, directions.Length)];
		bool isBlocked = Physics2D.Linecast(position, position + direction, npcMask);
		return direction;
	}
}
