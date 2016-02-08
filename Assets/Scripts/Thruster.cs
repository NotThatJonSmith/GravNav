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
    public float thrust;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && upUses > 0) {
            upUses--;
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(upVector * thrust, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && downUses > 0) {
            downUses--;
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(downVector * thrust, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && leftUses > 0) {
            leftUses--;
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(leftVector * thrust, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && rightUses > 0) {
            rightUses--;
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(rightVector * thrust, ForceMode.Force);
        }
    }

    void FixedUpdate() {

    }
}