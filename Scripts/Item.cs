using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	string name;
	string type;
	int value;
	int amount;
	//icon
	public Item (string name){
		this.name = name;

	}

	public string getName(){
		return this.name;
	}
}
