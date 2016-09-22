using UnityEngine;
using System.Collections;

public class PlayerSoundController : MonoBehaviour {
	AudioSource audioSource;
	public AudioClip [] clipDataBase;
	int i=0;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent <AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void PlayerStep(){
		

	
		AudioClip randomFootstep= clipDataBase[i];
		i++;
			if(i==(clipDataBase.Length-1)){
				i = 0;
			}
		audioSource.PlayOneShot(randomFootstep);



			
			

	}
}
