using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript S;
	private Rigidbody rigid;
    public int pickups = 0;
    public int pickupsNeeded = 0;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error: No RigidBody on Player!");
	}
	
	void Awake() {
		if (S) {
			Debug.Log("Multiple players. Error.");
			return;
		}
		S = this;
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude != 0f) {
			transform.rotation = Quaternion.LookRotation(Vector3.forward, rigid.velocity.normalized);
		}	
    }
	
    void OnCollisionEnter(Collision coll){
        Debug.Log("CONTACT.");
    }

	public void win() {
		gameObject.SetActive(false);
	}
	
}
