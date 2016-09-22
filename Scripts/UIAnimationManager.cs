using UnityEngine;
using System.Collections;
using System;

public class UIAnimationManager : MonoBehaviour {
	Animator anim;
	GameObject reciever;
	GameObject Information;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Information = GameObject.Find ("Information");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ShowSelf(GameObject sender){
		anim.Play ("OpenDialogueBox");
		print ("played");
		this.reciever = sender;
	}

	void ShowNotification(){
		anim.Play ("PopUp");
	}
	void ClearNotification(){
		Information.SendMessage ("SetDialogue","");
	}
	void StartDialogue(){
		
		reciever.SendMessage ("ReadyToDisplay");
		reciever.SendMessage ("StartDialogue");
		
	}
	void HideSelf(GameObject portrait){
		anim.Play ("CloseDialogueBox");
		reciever = portrait;

	}

	void closePortrait(){
		reciever.SendMessage ("HideFace");	

	}
}
