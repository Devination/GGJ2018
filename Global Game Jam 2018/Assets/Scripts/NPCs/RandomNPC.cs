using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPC : GeneralNPC {
	[SerializeField] float speed = 5;
	[SerializeField] float moveTime = 1;
	[SerializeField] float delayTime = 1;

	Vector2[] directions = new Vector2[] {Vector2.up , Vector2.down, Vector2.left, Vector2.right};

	protected override void Start () {
		base.Start();
		StartCoroutine(Movement());
	}

	IEnumerator Movement() {
		while (true) {
			yield return new WaitForSeconds(delayTime);
			Vector2 direction = GetOpenDirection();
			body.AddForce(direction * speed, ForceMode2D.Impulse);
			yield return new WaitForSeconds(moveTime);
			body.velocity = Vector2.zero;
		}
	}

	Vector2 GetOpenDirection() {
		Vector2 position = transform.position;
		Vector2 direction;
		bool isBlocked = false;
		do {
			isBlocked = false;
			direction = directions[Random.Range(0, directions.Length)];
			//Debug.DrawLine(position, position + direction);
			foreach (RaycastHit2D hit in Physics2D.LinecastAll(position, position + direction)) {
				if (hit.transform != this.transform) {
					isBlocked = true;
					break;
				}
			}
		} while (isBlocked);
		return direction;
	}
}
