using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {
	GameObject GreenKey;
	GameObject BlueKey;
	GameObject WhiteKey;
	// Use this for initialization
	void Start () {
		GreenKey = GameObject.Find ("GreenKey");
		BlueKey = GameObject.Find ("BlueKey");
		WhiteKey = GameObject.Find ("WhiteKey");
		GreenKey.SetActive (false);
		WhiteKey.SetActive (false);
		BlueKey.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Green_Key(){
		GreenKey.SetActive (true);
	}
	void White_Key(){
		WhiteKey.SetActive (true);
	}
	void Blue_Key(){
		BlueKey.SetActive (true);
	}
}
