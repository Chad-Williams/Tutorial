using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;using System.Xml;
using System.Xml.Serialization;


public class SaveGame : MonoBehaviour {
	GameObject player;
	Game game;
	string save;
	Vector3 position;
	Quaternion rotation;
	GameObject canvas;
	string scene;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		canvas = GameObject.Find ("Canvas");
	}

	public void SaveState(int slot){
		save = Application.dataPath+"/SaveData 0"+slot+".sav";
		rotation = new Quaternion (player.transform.rotation.x,player.transform.rotation.y,player.transform.rotation.z,player.transform.rotation.w);
		scene = Application.loadedLevelName;
		print (scene);

		game = new Game (player.transform.position.x,
	    player.transform.position.y,player.transform.position.z,scene);

		if (System.IO.File.Exists (save)) {
			canvas.gameObject.SendMessage ("showConfirm", "Want To Overwrite  File 0" + slot + "?");
		} else {
			canvas.gameObject.SendMessage ("showConfirm", "Create Save On Slot  0" + slot + "?");
		}


	}

	public void SaveGameData(){
		var bf = new XmlSerializer(typeof(Game));
		FileStream saveFile = File.Create (save);
		bf.Serialize(saveFile, game);
		saveFile.Close();
		print ("SAVED");

	}

	public void LoadState(int slot){
		canvas = GameObject.Find ("Canvas");
		save = Application.dataPath+"/SaveData 0"+slot+".xml";


		if(System.IO.File.Exists(save)){
			canvas.gameObject.SendMessage ("showConfirm","Load File 0"+slot+"?");
		} else {
			canvas.gameObject.SendMessage ("showConfirm","To Show no data on button in future");
		}


	}


	public void LoadGame(){
		var stream = new FileStream(save, FileMode.Open);
		var serializer = new XmlSerializer(typeof(Game));
		game = serializer.Deserialize(stream) as Game;
		Application.LoadLevel (game.scene);
		Time.timeScale = 1;
		player=GameObject.Find("player");
		player.transform.position = new Vector3 (game.x,game.y,game.z);
	}

}
