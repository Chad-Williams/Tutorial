using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour {

	public static SceneManager Instance;
	// Use this for initialization
	void Awake() {
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if(Instance!=this) {
			Destroy (gameObject);
		}


	}
	
	public void SwitchScene(string sceneName){
		Time.timeScale = 1;
		Application.LoadLevel (sceneName);

	}

	public void QuitGame(){
		Application.Quit ();
	}
}
