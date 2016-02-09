using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public static GameObject S;
	private Rigidbody rigid;
	public Vector3 initialVelocity;
	public PlanetScript[] attractors;
	public Vector3 lastAppliedForce;
    public int pickups = 0;
    public int pickupsNeeded = 0;

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
	
	void Update() {
		drawTrajectory();
	}

	void FixedUpdate() {
		foreach (PlanetScript ps in attractors) {
			if (ps.disableForce) continue;
			lastAppliedForce = gravity(ps, transform.position);
			rigid.AddForce(lastAppliedForce);
		}
		if (rigid.velocity.magnitude != 0f) {
			transform.rotation = Quaternion.LookRotation(Vector3.forward, rigid.velocity.normalized);
		}
		
    }
	
	Vector3 gravity(PlanetScript ps, Vector3 pos) {
		Vector3 displacement = ps.gameObject.transform.position - pos;
		return displacement.normalized * ps.strengthOfAttraction / displacement.magnitude;
	}

	void OnDrawGizmos() {
		Gizmos.DrawLine(transform.position, transform.position + 4 * lastAppliedForce);
	}

	public float forecastTime = 100.0f;
	public float deadZoneRadius = 2f;
	void drawTrajectory() {
		int trajectorySteps = (int)(forecastTime / Time.timeScale);
		Vector3 pos = transform.position;
		Vector3 vel = rigid.velocity;
		for (int i = 0; i < trajectorySteps; i++) {
			Vector3 cumulativeForce = Vector3.zero;
			foreach (PlanetScript ps in attractors) {
				if (ps.disableForce) continue;
				cumulativeForce += gravity(ps, pos);
			}
			Vector3 nextPos = pos;
			vel += cumulativeForce / rigid.mass / Time.timeScale;
			nextPos += vel / Time.timeScale;
			foreach (PlanetScript ps in attractors) {
				if (ps.disableForce) continue;
				if ((ps.gameObject.transform.position - nextPos).magnitude < deadZoneRadius) return;
			}
			Debug.DrawLine(pos, nextPos, Color.red);
			pos = nextPos;

		}
		
	}
}
