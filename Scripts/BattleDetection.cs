using UnityEngine;

using System.Collections;

public class BattleDetection : MonoBehaviour {
   
	GameObject player;
    // Use this for initialization
    void Start() {
		player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update() {

    }
	void OnTriggerEnter(Collider Col) {
		
		if(Col.gameObject.name.Equals("HitBox")){
		player.SendMessage ("addEnemy",this.gameObject);
		}
	}

	void OnTriggerExit(Collider Col) {

		if(Col.gameObject.name.Equals("HitBox")){
			player.SendMessage ("removeEnemy",this.gameObject);
		}
	}
    
}
