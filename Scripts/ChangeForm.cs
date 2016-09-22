using UnityEngine;

using System.Collections;

public class ChangeForm : MonoBehaviour {
    GameObject UnityChan;
    GameObject CandyRockStar;
	LockON LockOn;
	float time=3;
    Animator anim;
    Avatar UnityAvatar;
    Avatar CandyAvatar;
	// Use this for initialization
	void Start () {
        UnityChan = GameObject.FindGameObjectWithTag("Normal") ;
        CandyRockStar = GameObject.FindGameObjectWithTag("Candy");
		LockOn = GetComponent<LockON>();
		CandyRockStar.SetActive(false);
        anim = GetComponent<Animator>();
        UnityAvatar = Resources.Load("unitychan", typeof (Avatar)) as Avatar;
        CandyAvatar = Resources.Load("CandyRockStar", typeof(Avatar)) as Avatar;
    }

    // Update is called once per frame
   
     
            
       
	void Update () {
		if (LockOn.target==null&&PLAYERSTATE.isNotBusy)
		{   
			
				time -= Time.deltaTime;
			if(time<=0){

            CandyRockStar.SetActive(false);
            UnityChan.SetActive(true);
           
				anim.avatar = UnityAvatar;}
        }
		if (LockOn.target!=null&&PLAYERSTATE.isNotBusy)
        {
            CandyRockStar.SetActive(true);
            UnityChan.SetActive(false);
            anim.avatar = CandyAvatar;
			time = 3;
        }
    }

}
