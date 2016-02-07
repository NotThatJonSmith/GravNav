using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {
    //The forward direction of the ship
    //Thrust is applied opposite this
    public Vector3 forwardVector;
    //Multiplies the forwardVector to determine the force
    public float thrust;
    //The starting fuel in seconds
    public float initialFuel;
    //How much fuel is left
    //This does not need to be set in the Inspector
    public float remainingFuel;
    //If true, the force is being applied
    public bool active;

    // Use this for initialization
    void Start() {
        remainingFuel = initialFuel;
        active = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("space") && remainingFuel > 0) {
            active = true;
            remainingFuel -= Time.deltaTime;
        } else {
            active = false;
        }
    }

    void FixedUpdate() {
        if (active) {
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(forwardVector * thrust * -1, ForceMode.Impulse);
        }
    }
}