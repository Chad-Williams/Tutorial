
using UnityEngine;
using System.Collections;

public class EthanEnemy : EnemyBase {
	Animator ethanAnimator;
	NavMeshAgent agent;
	int stage=3;
	bool isFree =true;
	GameObject player;
	GameObject target=null;
	bool Attacking=false;
	string animationZ="Hurt";
	// Use this for initialization
	void Start () {
		HP = 50;
		player = GameObject.Find("player");
		agent = GetComponent<NavMeshAgent> ();
		ethanAnimator = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		float curDistance =CheckDistance (player);
		//STAGES
		if(curDistance<=80){
			//ENABLE
		}
		if (curDistance <= 30) {
			stage = 2;
			ethanAnimator.SetBool ("Battle", true);
		} else {
			stage = 3;
			ethanAnimator.SetBool ("Battle", false);
		}

		float spawnerDistance = CheckDistance (spawner);

		if(spawnerDistance>=600&this.gameObject.name.Contains("Clone")){
			spawner.SendMessage("Return",this.gameObject);
			//Animation to return
			Destroy(this.gameObject);
		}


		//++++++++++++=================+++++++++++++
		if(!Attacking){
		transform.LookAt (player.transform.position);
			transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);}
		
	

		if (HP <= 0) {
			death ();

		}
		if(this.enabled){
			agent.destination = player.transform.position;
		}

			
	}
	public void SetHP()
	{
		Battle.setTargetHP (HP);
	
	}
	public void TakeDmg(int amount)
	{
		isFree = false;
		HP -=amount;
		print (HP);
		if (animationZ.Equals ("Hurt")) {
			animationZ = "Hurt2";
		} else {
			animationZ = "Hurt";
		}
		ethanAnimator.Play (animationZ);
	}
	void death(){
		isFree = false;
		spawner.SendMessage ("RemoveEnemy",enemyCode);
		player.SendMessage ("removeEnemy",this.gameObject);
		ethanAnimator.Play ("Death");
	}
	void Dead (){
		Destroy (this.gameObject);
	}

	void Attack(){
		target = player;
		if(isFree){
			Attacking = true;
			ethanAnimator.Play ("Unarmed-Attack-Kick-R1");

		}
	}

	void DmgPlayer(){
		if(target!=null){
		player.SendMessage ("TakeDmg",10);
		}
	}



	void AttackOver(){
		Attacking = false;
	}
	void Free(){
		isFree = true;
	}
	void OutOfRange(){
		target = null;
	}



	float CheckDistance(GameObject item){
		if(agent.pathStatus==NavMeshPathStatus.PathPartial){
			agent.Stop ();
			if (this.gameObject.name.Contains ("Clone")) {

				spawner.SendMessage ("Return", this.gameObject);
				//Animation to return

				Destroy (this.gameObject);
			}

		}

		float mDistance=0;
		if (spawner != null) {
			var diff = (transform.position - item.transform.position);
			mDistance = diff.sqrMagnitude;
		}
		return mDistance;
	}
	void Activate(){
		transform.position = spawner.transform.position;
	}


}
