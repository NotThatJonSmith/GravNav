using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

	public float strengthOfAttraction = 0;
	public bool _disableForce = true;
	public Material[] mats;
	public Renderer rend;

	void Awake() {
		rend = GetComponent<Renderer>();
	}

	void setMaterial() {
		if (mats.Length < 2) return;
		rend.sharedMaterial = mats[disableForce?0:1];
	}

	void Start() {
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
