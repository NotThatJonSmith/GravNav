using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrajectoryForecast : MonoBehaviour {

	GravityMotion gm;
	LineRenderer lr;

	void Start() {
		gm = GetComponent<GravityMotion>();
		if (gm == null) print("Error: No GravityMotion on an object with a TrajectoryForecast!");
		lr = GetComponent<LineRenderer>();
		if (gm == null) print("Error: No LineRenderer on an object with a TrajectoryForecast!");
	}
	
	void Update() {
		drawTrajectory();
	}

	public float forecastTime = 4.0f;
	public float deadZoneRadius = 2f;
	public float granularity = 0.1f;

	void drawTrajectory() {
		int trajectorySteps = (int)(forecastTime / granularity);
		Vector3 pos = transform.position;
		Vector3 vel = gm.rigid.velocity;
		Vector3[] points = new Vector3[trajectorySteps + 1];
		points[0] = pos;
		for (int i = 0; i < trajectorySteps; i++) {
			Vector3 cumulativeForce = Vector3.zero;
			foreach (PlanetScript ps in gm.attractors) {
				if (ps.disableForce) continue;
				cumulativeForce += gm.gravity(ps, pos);
			}
			Vector3 nextPos = pos;
			vel += cumulativeForce / gm.rigid.mass * granularity;
			nextPos += vel * granularity;
			pos = nextPos;
			points[i + 1] = pos;
		}
		lr.SetVertexCount(trajectorySteps + 1);
		lr.SetPositions(points);
	}
}
