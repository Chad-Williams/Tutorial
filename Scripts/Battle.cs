using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;

public class Battle : MonoBehaviour {
    public Animator anim;
    public string playingAnimation = "HOW";
    private ThirdPersonCharacter m_Character;
    private LockON lockOn;
	Avatar PlayerAvatar;
	GameObject enemy;
	int playerHP=50;
    public static bool Player_Attacking;
    public string[] combo = { "Unarmed-Attack-L3", "Unarmed-Attack-R3", "Unarmed-Attack-Kick-L1", "" };
    int enemyHP = 0;
	private ArrayList EnemiesInRange= new ArrayList();
	public static int targetHP = 100;
	GameObject [] Lazers;
	Rigidbody body;


    // Use this for initialization
    void Start() {
		
        anim = GetComponent<Animator>();
		body = GetComponent<Rigidbody> ();
        m_Character = GetComponent<ThirdPersonCharacter>();
        lockOn = GetComponent<LockON>();
		Lazers = GameObject.FindGameObjectsWithTag ("Lazer");
		foreach(GameObject lz in Lazers){
			lz.SetActive (false);
		}
		PlayerAvatar = anim.GetComponent<Avatar> ();
    }




    // Update is called once per frame
    void FixedUpdate() {
        //================================================================================
        //Check Animation
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Grounded")) {
			anim.SetInteger ("Combo", 0);
			anim.SetBool ("Attacking", false);
			anim.SetBool ("Next", false);
			Player_Attacking = false;
			foreach (GameObject lz in Lazers) {
				lz.SetActive (false);
			}
			PLAYERSTATE.isNotBusy = true;
		}
        //================================================================================
        //ATTACKS 
		if(anim.avatar.name.Equals("CandyRockStarAvatar")){ //All Abilities allowed only in Celestial Body Goes here!
			if (CrossPlatformInputManager.GetButtonDown("Fire1")&&PLAYERSTATE.isNotBusy) {
				Player_Attacking = true;
				playingAnimation = combo[anim.GetInteger("Combo")];
				Attack();

			}

			if(CrossPlatformInputManager.GetButtonDown("Fire2")&&PLAYERSTATE.isNotBusy){
				PLAYERSTATE.isNotBusy=false;
				if(transform.position.y>=0){
					body.isKinematic =true;
				}
				anim.SetFloat ("Forward",0);
				anim.SetFloat ("Turn",0);
				if (lockOn.lockedOn)
				{
					m_Character.transform.rotation = lockOn.m_Cam.transform.rotation;

				}
				foreach(GameObject lazer in Lazers){
					lazer.SetActive (true);
					lazer.transform.rotation = m_Character.transform.rotation;
					if(lockOn.target!=null){
						lazer.transform.LookAt (lockOn.target.transform.position);
					}
					anim.Play ("BeamStance");

				}
			}

		}


		if (CrossPlatformInputManager.GetButtonDown("Fire3")&&PLAYERSTATE.isNotBusy)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            { anim.Play("forwardroll_10_p", -1, 0); }

        }


        //==================================================================================
        //HP CHECK
	



}
	void ReturnKinematicState(){
		body.isKinematic =false;
	}

	void CloseDistance(){ 
		if(lockOn.target!=null){
		if(IsOutOfRange(lockOn.target)){
			var diff = (transform.position - lockOn.target.transform.position);
			var mDistance = diff.sqrMagnitude/5;
				focusEnemy ();
					transform.Translate (0,0,mDistance);
			
			

			}
		}
	}

	bool IsOutOfRange(GameObject target){
		bool outOfRange=true;
		foreach(GameObject enemy in EnemiesInRange){

			if(target==enemy){
				outOfRange = false;
			}
		}
		return outOfRange;
	}
	//--------------=============================------------------------------------

    public void Attack()
    {


        if (anim.GetCurrentAnimatorStateInfo(0).IsName(playingAnimation))
        {
            anim.SetInteger("Combo", anim.GetInteger("Combo") + 1);

        }


		if (lockOn.target!=null)
        {
			focusEnemy ();
        }
        if (anim.GetInteger("Combo") == 0) {
            anim.Play(combo[0], -1, 0);
           
        }


        if (anim.GetInteger("Combo") == 1) {
          
            anim.SetBool("Attacking", true);
        }

        if (anim.GetInteger("Combo") == 2)
        { 
           
            anim.SetBool("Next", true);
        }
        if (anim.GetInteger("Combo") == 3) {
          
        }

    }
	//========================================================================
	//DAMAGE SECTION

	public void DoDmg(int Dmg) {
		if(lockOn.target!=null){
		lockOn.target.SendMessage ("TakeDmg",Dmg);
		}
    }
	void Hit(){
		foreach (GameObject enemy in EnemiesInRange){
			enemy.SendMessage ("TakeDmg",10);

		}
	}


	void BeamsGo(){
		foreach (GameObject lazer in Lazers) {

			Animator lazerAnimator = lazer.GetComponent<Animator> ();

			lazerAnimator.Play ("Start");
		}
	}
	//========================================================================
	void addEnemy(GameObject enemy){
		EnemiesInRange.Add(enemy);
		displayArray();
	}

	void removeEnemy(GameObject enemy){
		EnemiesInRange.Remove(enemy);
		displayArray ();
	}

	void displayArray(){
		foreach (GameObject enemy in EnemiesInRange){
			print (enemy);
		
		}
	}



	//==========================================================================
    void OnGUI(){
		GUI.Label(new Rect(400,10,100,20),"Player HP: "+playerHP) ;
		if(lockOn.target!=null){
			lockOn.target.SendMessage ("SetHP");
		GUI.Label(new Rect(10,10,100,20),"HP: "+targetHP) ;
		}
		if(lockOn.target==null){
		 GUI.Label(new Rect(10,10,100,20),"NOT LOCKED ON") ;
		}
	}
	public static void setTargetHP(int Value){
		targetHP = Value;
	}
	//==============================================================================
	//Trigger Start

	void OnTriggerEnter(Collider Col) {
		
			enemy = Col.gameObject;
		if (enemy.name.Contains ("Ethan")) {
			enemy.SendMessage ("Attack");
			print ("ATTACKED");
		} else {
		}
	}	


	
	void OnTriggerStay(Collider Col) {

		enemy = Col.gameObject;
		if(enemy.name.Contains ("Ethan")){
			enemy.SendMessage ("Attack");
		}



	}
	void OnTriggerExit(Collider Col) {

		enemy = Col.gameObject;
		if (enemy.name.Contains ("Ethan")) {
			enemy.SendMessage ("OutOfRange");
		} else {
		}
	}

	//Trigger End
	//=================================================================================================

	void TakeDmg(int amount){
		
		PLAYERSTATE.isNotBusy = false;
		playerHP -= amount;
		anim.Play ("Damage");
		}


	void focusEnemy(){
		m_Character.transform.rotation = new Quaternion(0, lockOn.cube.transform.rotation.y, 0, lockOn.cube.transform.rotation.w);
	}
}
