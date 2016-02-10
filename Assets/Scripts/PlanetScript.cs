using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

	public float strengthOfAttraction = 0;
	public bool _disableForce = false;
	public Material[] mats;
	public Renderer rend;

	void Awake() {
		rend = GetComponent<Renderer>();
	}

	void setMaterial() {
		rend.sharedMaterial = mats[disableForce?0:1];
	}

	void Start() {
		disableForce = true;
		setMaterial();
	}

	public bool disableForce {
		get {
			return _disableForce;
		}

		set {
			_disableForce = value;
			setMaterial();
		}
	}

	void OnMouseDown() {
		disableForce = !disableForce;
        if (!disableForce) {
            ClickCounter.instance.clickCount++;
        }
	}




}
