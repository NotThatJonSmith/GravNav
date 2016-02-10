using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrajectoryForecast : MonoBehaviour {
	
	private Rigidbody rigid;
	public PlanetScript[] attractors;
	public LineRenderer lr;
	public int pickups = 0;
	public int pickupsNeeded = 0;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		lr = GetComponent<LineRenderer>();
		if (rigid == null) print("Error! No Rigidbody component found");
		if (lr == null) print("Error! No LineRenderer component found");
	}
	

	void Update() {
		drawTrajectory();
	}

	private float forecastTime = 4.0f;
	private float deadZoneRadius = 2f;
	private float granularity = 0.1f;

	void drawTrajectory() {
		int trajectorySteps = (int)(forecastTime / granularity);
		Vector3 pos = transform.position;
		Vector3 vel = rigid.velocity;
		Vector3[] points = new Vector3[trajectorySteps + 1];
		points[0] = pos;
		for (int i = 0; i < trajectorySteps; i++) {
			Vector3 cumulativeForce = Vector3.zero;
			foreach (PlanetScript ps in attractors) {
				if (ps.disableForce) continue;
				cumulativeForce += GravityMotion.gravity(ps, pos);
			}
			Vector3 nextPos = pos;
			vel += cumulativeForce / rigid.mass * granularity;
			nextPos += vel * granularity;
			foreach (PlanetScript ps in attractors) {
				if (ps.disableForce) continue;
				if ((ps.gameObject.transform.position - nextPos).magnitude < deadZoneRadius) return;
			}
			//Debug.DrawLine(pos, nextPos, Color.red);
			pos = nextPos;
			points[i + 1] = pos;
		}
		lr.SetVertexCount(trajectorySteps + 1);
		lr.SetPositions(points);
	}
}
