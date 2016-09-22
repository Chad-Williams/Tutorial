using UnityEngine;
using System.Collections;

public class DoorEvent : MonoBehaviour {
	bool active=false;
	bool doorKey=false;
	GameObject door;
	Inventory inventory;
	public float speed=6;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");

	}

	// Update is called once per frame
	void Update () {
		if (door != null) {
			if (door.transform.position.y < 11f & active) {
				door.transform.Translate (Vector3.up * 6 * Time.deltaTime);
			}
			if (door.transform.position.y > 4 & active == false) {
				door.transform.Translate (Vector3.down * 6 * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter(Collider col){

		if(col.gameObject.name.Contains("Door")& active == false){
			if(col.gameObject.name.Contains("GreenDoor")){
				player.SendMessage ("Has", "Green_Key");
				OpenDoor (col);

			}
			if(col.gameObject.name.Contains("WhiteDoor")){
				player.SendMessage ("Has", "White_Key");
				OpenDoor (col);

			}
			if(col.gameObject.name.Contains("BlueDoor")){
				player.SendMessage ("Has", "Blue_Key");
				OpenDoor (col);

			}

			if(col.gameObject.name.Contains("ExitDoor")){
				player.SendMessage ("Has", "Exit_Key");
				OpenDoor (col);

			}
		
         }
     }


	void OnTriggerExit(Collider col){
		
		if(col.gameObject.name.Contains("Door")& active){
			door = col.gameObject;
			active = false;
			doorKey = false;

		}
	}

	void HasItem(){
		doorKey = true;
	}

	void OpenDoor(Collider col){
		if(doorKey==true){
			door = col.gameObject;
			active = true;
		}

	}

}
