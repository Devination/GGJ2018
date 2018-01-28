using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField] GameObject[] npcPrefabs; 
	[SerializeField] Vector2 range;

	void Start () {
		StartCoroutine( SpawnLoop() );
	}
	
	IEnumerator SpawnLoop() {
		while ( true ) {
			yield return new WaitForSeconds( 5 );
			Spawn();
		}
	}

	void Spawn() {
		Vector2 position = new Vector2( Random.Range( -range.x, range.x ), Random.Range( -range.y, range.y ) );
		GameObject npc = npcPrefabs[Random.Range(0, npcPrefabs.Length)];
		Instantiate( npc, position, Quaternion.identity );
	}
}
