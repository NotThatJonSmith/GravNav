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

    void Update()
    {
        if (disableForce)
        {
            transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, .1f, 1);
        }
        else
        {
            transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, 1, 1);
        }
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
