using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	GameObject ethan;
	GameObject player;
	bool spawned=false;

	public ArrayList enemies=new ArrayList(); //current enemies
	public GameObject [] enemyList; //enemy database

	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		UpdateEnemies ();

		foreach(GameObject Enemy in enemies){
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		var diff = (transform.position - player.transform.position);
		var curDistance = diff.sqrMagnitude;

		if (curDistance <= 50 & !spawned) {
			UpdateEnemies ();

			if (enemies != null) {
				int code =0;

				foreach (GameObject enemy in enemies) {
					
					if (enemy != null) {
						Spawn (enemy,code);

					}

					code++;
				}



				enemies.Clear ();
				spawned = true;
				print ("ENEMIES CLEARED");
			}
		}
	
	}

	void Spawn(GameObject enemy,int code){
		GameObject spawnedEnemy = (GameObject) Instantiate (enemy, new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Quaternion (0, 0, 0, 0));
			spawnedEnemy.SendMessage ("setSpawner", this.gameObject);
		    spawnedEnemy.SendMessage ("setCode",code);
		}

	void Return(GameObject returnEnemy){
		for(int i=0;i<enemyList.Length;i++){
			if(returnEnemy==enemyList[i]){
				enemyList [i] = null;
				break;
			}
		}

		print ("RETURNED!");
		spawned = false;
	}

	void UpdateEnemies(){
		enemies.Clear ();
		for(int i=0;i<enemyList.Length;i++){
			if (enemyList [i] != null) {
				enemies.Add (enemyList [i]);
			} else {
			    
			}
		}
	}

	void RemoveEnemy(int code){
		enemyList [code] = null;
	}

}
