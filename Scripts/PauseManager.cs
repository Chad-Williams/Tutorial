using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PauseManager : MonoBehaviour {
	GameObject[] componants;
	GameObject[] MessagePaneComponants;
	bool saving=false;
	bool paused=false;
	// Use this for initialization
	void Start () {
		MessagePaneComponants = GameObject.FindGameObjectsWithTag ("MessagePane");
		componants=GameObject.FindGameObjectsWithTag("PauseMenu");
		setDialoguecomponants (false,componants);
		Cursor.visible = false;
		paused = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(CrossPlatformInputManager.GetButtonDown("Cancel")){
			if(saving){
				setDialoguecomponants (false,MessagePaneComponants);
			}
			else if(paused){
				setDialoguecomponants (false,componants);
				Cursor.visible = false;
				paused = false;
				Time.timeScale = 1;
			}
			else if(!paused){
				setDialoguecomponants (true,componants);
				Cursor.visible = true;
				paused =true;
				Time.timeScale = 0;
			}


		}
	}
	void setDialoguecomponants(bool status,GameObject[]gameComponants){

		foreach(GameObject componant in gameComponants){
			componant.gameObject.SetActive (status);
		
		}
	}
}
