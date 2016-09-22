using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {
	public int HP;
	public GameObject spawner=null;
	public int enemyCode;
	// Use this for initialization
	public int getHP(){
		return this.HP;
	}
	public EnemyBase(){
	}
	public EnemyBase(int HP){
		this.HP = HP;
	}


	public void setSpawner(GameObject objectSpawner){
		spawner = objectSpawner;
	}
	public void setCode(int code){
		enemyCode = code;
	}


}
