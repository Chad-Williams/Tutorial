using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;


public class LockON : MonoBehaviour {

    public GameObject[] enemyList;
    public GameObject target=null;

    public bool lockedOn = false;
    private ThirdPersonCharacter m_Character;
    public Transform m_Cam;
    public GameObject cube;
    

    // Use this for initialization
    void Start() {
        if (Camera.main != null)
        {
            m_Cam = GameObject.Find("MouseCamera").transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }
        m_Character = GetComponent<ThirdPersonCharacter>();
        cube = GameObject.Find("root");

        

    }

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {

		FindTarget ();


		if (CrossPlatformInputManager.GetButtonDown("Fire5")&&PLAYERSTATE.isNotBusy)
		{   
			lockedOn = true;
			print ("LOCKED ON DESKA");
		}

		if (CrossPlatformInputManager.GetButtonDown("Fire6")&&PLAYERSTATE.isNotBusy)
		{lockedOn = false;
		}

		if(target == null){
			lockedOn = false;
		}


        if (lockedOn){
			cube.transform.LookAt (target.transform.position);
			m_Cam.transform.rotation = new Quaternion(0, cube.transform.rotation.y, 0, cube.transform.rotation.w);
        }
    }
  
	void FindTarget(){
		enemyList = GameObject.FindGameObjectsWithTag("Enemy");

		float distance = Mathf.Infinity;
		var position = m_Character.transform.position;
		//Finds Target
		for (int i = 0; enemyList.Length > i; i++)
		{
			var diff = (enemyList[i].transform.position - m_Character.transform.position);
			var curDistance = diff.sqrMagnitude;

			if (curDistance < distance)
			{
				if (curDistance < 200) {
					target = enemyList [i];


				} else {
					target =null;
				}


			}
		}//FOR
		if(target!=null){
		cube.transform.LookAt(target.transform.position);
		}}

}
