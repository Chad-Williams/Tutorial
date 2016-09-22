using UnityEngine;
using System.Collections;

public class StoryEvent : MonoBehaviour {
	GameObject EventSystem;
	GameObject player;
	static int eventCounter=0;
	int thisValue=0;
	string name;
	// Use this for initialization
	void Start () {
		EventSystem = GameObject.Find ("EventSystem");  
		player = GameObject.Find("player");
		name = this.gameObject.name;
	
		string []line = name.Split('(');
		string[] value = line[1].Split (')'); 
		thisValue = int.Parse(value [0]);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider Col){
		if(thisValue==eventCounter){
		if(Col.gameObject.name.Equals("HitBox")){
			EventSystem.SendMessage ("StartMainDialogue",this.gameObject);
			}}
	}

	void EndEvent(){
		eventCounter++;
		Destroy(this.gameObject);
	}
}
