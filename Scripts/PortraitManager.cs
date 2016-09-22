using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PortraitManager : MonoBehaviour {
	string characterName;
	GameObject reciever;
	Image characterPortrait;
	int character;
	string previousName="";
	bool sameFace;
	Animator anim;
	Sprite[,]characterPortraits=new Sprite[3,6];
	string[]names=new string[3];
	// Use this fr initialization
	void Start () {
		characterPortrait = GetComponent<Image> ();
		anim = GetComponent<Animator> ();
		names[0]="kohaku";
		names[1]="marie";
		names[2]="misaki";
		createPortraits (names);
	}

	void SelectCharacter(string name){
		//Determines If it transitions to a new character or not
		if (name.Equals (previousName)) {
			sameFace = true;
		} else {
			sameFace = false;
		}

		//Gets the character to select the correct portrait using the names array as a means
		for(int i=0;i<names.Length;i++){
			if(names[i].Equals(name)){
				character = i;
				previousName = name;
			}

		}
	}

	void SetEmotion(int emotion){
		//uses variable set in SelectCharacter Method to switch faces or not
		if(!sameFace){
			//TO BE ADDED
		}
		//sets the sprite
		characterPortrait.sprite=characterPortraits[character,(emotion-1)];


	}
	//Initializes all the portraits, all portraits should follow naming convention!
	// portrait_[character name]_0[number]
	void createPortraits(string []name){
		for(int j=0;j<names.Length;j++){
		for(int i=0;i<6;i++){
			string load = "portrait_"+name[j]+"_0"+(i+1);
			//print (load);
			characterPortraits[j,i]= Resources.Load(load,typeof (Sprite)) as Sprite;
			}
		}
	}

	void HideFace(){
		anim.Play ("Disappear");
	}
	void ShowSelf(GameObject sender){
		
		anim.Play ("Appear");
		reciever = sender;
	}

	void DisplayDialogueBox(){
		reciever.SendMessage ("DialogueBoxShow");
	}
}
