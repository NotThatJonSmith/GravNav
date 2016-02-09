using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public static GameObject S;
	private Rigidbody rigid;
	public Vector3 initialVelocity;
	public PlanetScript[] attractors;
	public Vector3 lastAppliedForce;
	public LineRenderer lr;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		lr = GetComponent<LineRenderer>();
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

	private float forecastTime = 4.0f;
	private float deadZoneRadius = 2f;
	private float granularity = 0.1f;
	void drawTrajectory() {
		int trajectorySteps = (int)(forecastTime / granularity);
		Vector3 pos = transform.position;
		Vector3 vel = rigid.velocity;
		Vector3[] points = new Vector3[trajectorySteps+1];
		points[0] = pos;
		for (int i = 0; i < trajectorySteps; i++) {
			Vector3 cumulativeForce = Vector3.zero;
			foreach (PlanetScript ps in attractors) {
				if (ps.disableForce) continue;
				cumulativeForce += gravity(ps, pos);
			}
			Vector3 nextPos = pos;
			vel += cumulativeForce / rigid.mass * granularity;
			nextPos += vel * granularity;
			foreach (PlanetScript ps in attractors) {
				if (ps.disableForce) continue;
				if ((ps.gameObject.transform.position - nextPos).magnitude < deadZoneRadius) return;
			}
			Debug.DrawLine(pos, nextPos, Color.red);
			pos = nextPos;
			points[i + 1] = pos;

		}

		lr.SetVertexCount(trajectorySteps + 1);
		lr.SetPositions(points);
		
	}
}
