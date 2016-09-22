using UnityEngine;
using System.Collections;

public class CapsuleEnemy : MonoBehaviour {
	public int HP=30;
	GameObject player;
	GameObject targeter;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		targeter = GameObject.Find ("Ring Fx");
	}

	// Update is called once per frame
	void Update () {
		if(HP<=0){
			Destroy (this.gameObject);
			player.SendMessage ("removeEnemy",this.gameObject);
		}
	   
	}
	public void SetHP()
	{
		Battle.setTargetHP (HP);

	}
	public void TakeDmg(int Amount)
	{
		HP -=Amount;
		print (HP);
	}

}
