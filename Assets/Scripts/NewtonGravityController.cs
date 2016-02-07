using UnityEngine;
using System.Collections;

public static class Constants {
	public const double G = 10;
}

public class NewtonGravityController : MonoBehaviour {

    private Rigidbody rigid;
    public Vector3 initialVelocity;
    public GameObject[] attractors;

    void Start() {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = initialVelocity;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach (GameObject obj in attractors) {
			Rigidbody otherBody = obj.GetComponent<Rigidbody>();
			if (otherBody == null) continue;
			lastAppliedForce = NewtonGravity(otherBody);
			rigid.AddForce(lastAppliedForce);
        }
	}

	// Compute the gravitational force added to this rigid body
    Vector3 NewtonGravity(Rigidbody otherBody) {
        Vector3 displacement = otherBody.gameObject.transform.position - transform.position;
        return displacement.normalized * (float)(rigid.mass * otherBody.mass * Constants.G / Mathf.Pow(displacement.magnitude, 2));
    }

	public Vector3 lastAppliedForce;

	void OnDrawGizmos() {
		Gizmos.DrawLine(transform.position, transform.position+4*lastAppliedForce);
	}

}
