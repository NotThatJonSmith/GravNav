using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public GameObject explosionPrefab;

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

	void Update() {
		if (Input.GetKeyDown(KeyCode.A)) slowTime(2f);
	}
	
    void OnCollisionEnter(Collision coll){
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void win() {
		gameObject.SetActive(false);
	}

	public void slowTime(float timeOfEffect) {
		Invoke("resetTime",timeOfEffect);
		Time.timeScale = .5f;
	}
	
	public void resetTime() {
		Time.timeScale = 1f;
	}

}
