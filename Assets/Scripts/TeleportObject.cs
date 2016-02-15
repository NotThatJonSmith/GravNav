using UnityEngine;
using System.Collections;

public class TeleportObject : MonoBehaviour {

    public GameObject teleportTo;
    public bool incoming;

    private TeleportMaster tpM;


    // Use this for initialization
    void Start () {
        tpM = this.gameObject.transform.parent.GetComponent<TeleportMaster>();
        incoming = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.GetComponent<PlayerScript>() && !tpM.teleported) {
            coll.gameObject.GetComponent<ParticleSystem>().Play();
            coll.gameObject.transform.position = teleportTo.transform.position;
            teleportTo.GetComponent<TeleportObject>().incoming = true;
            tpM.teleported = true;
			GetComponent<AudioSource> ().Play ();
        }
    }

    void OnTriggerExit(Collider coll) {
        if (coll.gameObject.GetComponent<PlayerScript>() && incoming) {
            incoming = false;
            tpM.teleported = false;
        }
    }
}
