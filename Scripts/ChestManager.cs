using UnityEngine;
using System.Collections;

public class ChestManager : MonoBehaviour {
	bool opened = false;
	public string Item;
	GameObject player;
	Animator chestAnimator;
	GameObject Information;
	GameObject Box;
	// Use this for initialization
	void Start () {
		Box = GameObject.Find ("NotificationBox");
		player = GameObject.Find("player");
		chestAnimator = GetComponent<Animator> ();
		Information = GameObject.Find ("Information");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OpenChest(){
		if(opened==false){
			chestAnimator.Play ("Open Chest");
			Box.SendMessage ("ShowNotification",this.gameObject);
			Information.SendMessage ("SetDialogue","You Recvieved ["+Item+"] !");

			player.SendMessage ("addItem",new Item(Item));
			opened = true;
		}


	}

	void OnTriggerEnter(Collider Col){
		if(Col.gameObject.name.Equals("player")){
			
			Col.gameObject.SendMessage ("SetObjectInRange",this.gameObject);
		}
	}
	void OnTriggerExit(Collider Col){
		if(Col.gameObject.name.Equals("player")){
			Col.gameObject.SendMessage ("CancelObjectInRange");
		}
	}
}
