﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField] GameObject[] npcPrefabs; 
	[SerializeField] Vector2 range;
	public AudioClip[] deathClips;
	enum NPC {
		Follow,
		General,
		Random
	};
	public int followCount;
	int FORCE_FOLLOWER_CAP = 3;
	int rollsSinceLastFollower;
	int spawnedEnemies;

	void Start () {
		// HACK: This should probably be procedural;
		followCount = 0;
		StartCoroutine( SpawnLoop() );
		spawnedEnemies = 0;
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
		if( spawnedEnemies == 0 ) {
			NPCIndex = ( int )NPC.General;
		}
		else if( spawnedEnemies == 1 ) {
			NPCIndex = ( int )NPC.Random;
		}

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
			++followCount;
			rollsSinceLastFollower = 0;
		}
		GameObject npc = npcPrefabs[NPCIndex];
		Instantiate( npc, position, Quaternion.identity );
		spawnedEnemies++;
	}
}
