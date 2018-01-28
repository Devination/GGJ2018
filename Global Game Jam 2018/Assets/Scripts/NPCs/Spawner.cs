using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField] GameObject[] npcPrefabs; 
	[SerializeField] Vector2 range;
	enum NPC {
		Follow,
		General,
		Random
	};
	public int followCount;
	int FORCE_FOLLOWER_CAP = 2;
	int rollsSinceLastFollower;

	void Start () {
		// HACK: This should probably be procedural;
		followCount = 1;
		StartCoroutine( SpawnLoop() );
	}
	
	IEnumerator SpawnLoop() {
		while ( true ) {
			yield return new WaitForSeconds( 5 );
			Spawn();
		}
	}

	public void DecreaseFollowCount() {
		--followCount;
	}

	void Spawn() {
		Vector2 position = new Vector2( Random.Range( -range.x, range.x ), Random.Range( -range.y, range.y ) );
		int NPCIndex = Random.Range( 0, npcPrefabs.Length );
		if( NPCIndex == (int)NPC.Follow ) {
			++followCount;
			rollsSinceLastFollower = 0;
		}
		else {
			rollsSinceLastFollower++;
		}

		// Force a follower if we haven't rolled one in a while.
		if( followCount == 0 && rollsSinceLastFollower >= FORCE_FOLLOWER_CAP ) {
			NPCIndex = ( int )NPC.Follow;
		}
		GameObject npc = npcPrefabs[NPCIndex];
		Instantiate( npc, position, Quaternion.identity );
	}
}
