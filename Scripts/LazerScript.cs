using UnityEngine;
using System.Collections;

public class LazerScript : MonoBehaviour {
	GameObject player;
	Battle battle;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		battle = player.GetComponent<Battle> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Lazer(){
		battle.SendMessage ("DoDmg",10);

	}
}
