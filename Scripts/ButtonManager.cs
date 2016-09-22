using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	string scene;
	GameObject[]saveComponants;
	GameObject[]loadComponants;
	int i;
	public void Awake(){
		saveComponants = GameObject.FindGameObjectsWithTag ("Save Slot");
		loadComponants = GameObject.FindGameObjectsWithTag ("Load Slot");
	}
	public void Start(){
		i = 1;
	
		setDialoguecomponants (false, saveComponants);
		setDialoguecomponants (false, loadComponants);
	}

	public void changeScene(string scene){
		Time.timeScale = 1;
		Application.LoadLevel (scene);
}
	public void NewGame(){
		Time.timeScale = 1;
		Application.LoadLevel ("Maze");

	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void showLoadButtons(){

		if(i==1){
			setDialoguecomponants (true, loadComponants);
			i = 0;
			print ("Show Load Shiz"+loadComponants.Length);

		}
		else{
			setDialoguecomponants (false, loadComponants);
			i = 1;
		}


	}

	public void showSaveButtons(){

		if(i==1){
			setDialoguecomponants (true, saveComponants);
			i = 0;
		}
		else{
			setDialoguecomponants (false, saveComponants);
			i = 1;
		}
	}

	void setDialoguecomponants(bool status,GameObject[]gameComponants){

		foreach(GameObject componant in gameComponants){
			componant.gameObject.SetActive (status);

		}
	}



}
