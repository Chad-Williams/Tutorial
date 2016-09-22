using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    private Vector3 startPos;
    private Quaternion startRotation;
	// Use this for initialization
	void Start () {
        startPos =transform.position;
        startRotation = transform.rotation;
	}

    //Detect collision
    void OnTriggerEnter(Collider col) {
        if (col.tag == "death") {
            transform.position = startPos;
            transform.rotation= startRotation;
            GetComponent<Animator>().Play("LOSE00",-1,0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }

}
