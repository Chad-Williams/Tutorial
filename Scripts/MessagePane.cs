using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class MessagePane : MonoBehaviour {
	GameObject[] MessagePaneComponants;
	Text messageText;


	void Start(){
		MessagePaneComponants = GameObject.FindGameObjectsWithTag ("MessagePane");	
		messageText = GameObject.Find ("MessagePaneText").GetComponent<Text>();
		setMessageComponants (false);
	}

	public void showConfirm(string message){
		
		setMessageComponants (true);
		messageText.text = message;
	}
		
	public void setMessageComponants(bool status){

		foreach(GameObject componant in MessagePaneComponants){
			componant.gameObject.SetActive (status);

		}
	}

}
