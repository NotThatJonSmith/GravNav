using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {
    public Vector3  upVector;
    public int      upUses;
    public Vector3  downVector;
    public int      downUses;
    public Vector3  leftVector;
    public int      leftUses;
    public Vector3  rightVector;
    public int      rightUses;
    public bool thrustActive;
    public float thrust;
    public float thrustDuration;

    private Vector3 oldVelocity;
    private Rigidbody rigid;
    private SphereCollider coll;
    private Vector3 thrustVector;
    private float thrustTime;
    private bool resetVelocity;

    // Use this for initialization
    void Start() {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        coll = this.gameObject.GetComponent<SphereCollider>();
        thrustActive = false;
        resetVelocity = false;
    }

    // Update is called once per frame
    void Update() {
        if(Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
			upBoost ();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
			downBoost ();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			leftBoost ();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
			rightBoost ();
        }
    }

    void FixedUpdate() {
        if (resetVelocity) {
            resetVelocity = false;
            rigid.velocity = oldVelocity;
        }

        if (thrustActive && thrustTime > 0) {
            rigid.AddRelativeForce(thrustVector, ForceMode.VelocityChange);
            thrustTime -= Time.timeScale;
            if (thrustTime <= 0) {
                thrustActive = false;
                resetVelocity = true;
                coll.enabled = true;
            }
        }
    }

	public void upBoost() {
		if (upUses > 0) {
            coll.enabled = false;
			upUses--;
			oldVelocity = rigid.velocity;
			thrustActive = true;
			thrustVector = upVector * thrust;
			thrustTime = thrustDuration;
		}
	}

	public void downBoost() {
		if (downUses > 0) {
            coll.enabled = false;
            downUses--;
			oldVelocity = rigid.velocity;
			thrustActive = true;
			thrustVector = downVector * thrust;
			thrustTime = thrustDuration;
		}
	}

	public void leftBoost() {
		if (leftUses > 0) {
            coll.enabled = false;
            leftUses--;
			oldVelocity = rigid.velocity;
			thrustActive = true;
			thrustVector = leftVector * thrust;
			thrustTime = thrustDuration;
		}
	}

	public void rightBoost() {
		if (rightUses > 0) {
            coll.enabled = false;
            rightUses--;
			oldVelocity = rigid.velocity;
			thrustActive = true;
			thrustVector = rightVector * thrust;
			thrustTime = thrustDuration;
		}
	}
}