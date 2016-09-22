using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System;


public class DialogueEditor : MonoBehaviour {
	GameObject Name;
	bool readyToDisplay=false;
	GameObject[] componants;
	bool hasDialogue = true;
	GameObject Portrait;
	GameObject Dialogue;
	GameObject DialogueBox;
	string [] textData;
	Animator anim;
	string dialogueLine ;
	bool displayDialogue=false;
	int mainDialogueCounter=0;
	string line;
	string fileName;

	// Use this for initialization

	void Start () {

		DialogueBox = GameObject.Find ("DialogueBox");
		anim = GetComponent<Animator> ();
		componants=GameObject.FindGameObjectsWithTag("DialogueInterface");

		Name = GameObject.Find ("NameDialogue");
		Dialogue = GameObject.Find ("Dialogue");
		Portrait = GameObject.Find ("CharacterFace");

		TextAsset file = Resources.Load("Dialogue") as TextAsset;
		print (file);
		//print (fileName);


		textData = file.text.Split ('\n');


		dialogueLine = "" + textData [mainDialogueCounter];

	}

	// Update is called once per frame
	void Update () {
		if(hasDialogue){
		try{
			dialogueLine = "" + textData [mainDialogueCounter];
		}
		catch(Exception e){
				hasDialogue=false;
		}
		}
		if (displayDialogue == true) {
			Time.timeScale = 0;
			if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
				//print (dialogueLine);
				if (DialogueOutput.isTyping) {
					Dialogue.SendMessage ("SkipScroll");

				} else {
					mainDialogueCounter++;
					dialogueLine = "" + textData [mainDialogueCounter];
					print (dialogueLine);
					print (dialogueLine.Trim());
					if (dialogueLine.Trim().Equals ("END")) {
						print ("IS ENDED");
						mainDialogueCounter++;
						DialogueBox.SendMessage ("HideSelf", Portrait.gameObject);
						Time.timeScale = 1f; 
						displayDialogue = false;
						SendDialogue ("", "");
						readyToDisplay = false;

					} else {
						SortData (dialogueLine);
					}
				}
			}
		}

	}

	void SendDialogue(string name, string dialogue ){
		Name.SendMessage ("SetDialogue",name.ToUpperInvariant());
		Dialogue.SendMessage ("SetDialogueScroll",dialogue);
	}


	void SortData(string line){

		if(!line.Equals("END")){
			string[] data = line.Split ('#');
			string name = data [0];
			string dialogue = data [1];
			if(data.Length>2){
				string character = data[2];
				int emotion=int.Parse(character);
				Portrait.gameObject.SetActive (true);
				Portrait.SendMessage ("SelectCharacter",name);
				Portrait.SendMessage ("SetEmotion",emotion);

				Portrait.SendMessage ("ShowSelf",this.gameObject);

			}
			if(readyToDisplay){
				SendDialogue (name, dialogue);
			}

		}

	}
	//Starts the dialogue
	void StartMainDialogue(GameObject sender){
		sender.SendMessage ("EndEvent");//destroys the object that started this event to prevent duplicate dialogue
		Time.timeScale = 0;//pauses the game (not UI)

		SortData (dialogueLine);
	}

	void setDialoguecomponants(bool status){

		foreach(GameObject componant in componants){
			componant.gameObject.SetActive (status);

		}
	}

	void StartDialogue(){
		displayDialogue = true;
		SortData (dialogueLine);
	}

	void DialogueBoxShow(){

		DialogueBox.gameObject.SetActive (true);
		DialogueBox.SendMessage ("ShowSelf",this.gameObject);

	}

	void ReadyToDisplay(){
		readyToDisplay = true;
	}
}
