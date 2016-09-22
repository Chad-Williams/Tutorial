using UnityEngine;
using System.Collections;

public class DoorEventHandler : MonoBehaviour {
	Transform door;
	// Use this for initialization
	void Start () {
		door = GetComponentInParent<Transform> ().GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OpenDoor(){
		door.Translate (0,3,0);
	}

	void CloseDoor(){
		door.Translate (0,-3,0);
	}
}
