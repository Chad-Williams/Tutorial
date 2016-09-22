using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	ArrayList playerInventory = new ArrayList();
	GameObject player;
    GameObject Key;
	GameObject chest;

	bool hasItem;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		Key = GameObject.Find ("Key");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Has(string itemName){
		foreach(Item item in playerInventory){
			if(item.getName().Equals(itemName)){
				player.SendMessage ("HasItem");
			}
		}
	}


	void addItem(Item item){
		playerInventory.Add (item);
		Key.SendMessage (item.getName());

	}




}
