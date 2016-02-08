using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public static GameObject S;
	private Rigidbody rigid;
	public Vector3 initialVelocity;
	public PlanetScript[] attractors;
	public Vector3 lastAppliedForce;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error! No Rigidbody component on Player");
		rigid.velocity = initialVelocity;
	}
	
	void Awake() {
		if (S) {
			Debug.Log("Multiple players. Error.");
			return;
		}
		S = gameObject;
		// TODO populate the array with ALL attractors in scene?
	}
	
	void FixedUpdate() {
		foreach (PlanetScript ps in attractors) {
			if (ps.disableForce) continue;
			lastAppliedForce = gravity(ps);
			rigid.AddForce(lastAppliedForce);
		}
        this.gameObject.transform.LookAt(this.gameObject.transform.position + this.GetComponent<Rigidbody>().velocity, new Vector3(0, 0, 1));
    }
	
	Vector3 gravity(PlanetScript ps) {
		Vector3 displacement = ps.gameObject.transform.position - transform.position;
		return displacement.normalized * ps.strengthOfAttraction / Mathf.Pow(displacement.magnitude, 2);
	}

	void OnDrawGizmos() {
		Gizmos.DrawLine(transform.position, transform.position + 4 * lastAppliedForce);
	}
}
