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

	//TODO: Check if you're 
	IEnumerator Movement() {
		while (true) {
			yield return new WaitForSeconds(delayTime);
			Vector2 direction = directions[Random.Range(0, directions.Length)];
			body.AddForce(direction * speed, ForceMode2D.Impulse);
			yield return new WaitForSeconds(moveTime);
			body.velocity = Vector2.zero;
		}
	}
}
