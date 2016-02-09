using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupScript : MonoBehaviour {

    public float rotationSpeed = 5f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(1 * rotationSpeed, 1*rotationSpeed, 0));
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            PlayerScript.S.GetComponent<PlayerScript>().pickups += 1;
            Destroy(gameObject);
        }
    }
}
