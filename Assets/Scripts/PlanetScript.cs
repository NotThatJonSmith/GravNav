using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

	public float strengthOfAttraction = 0;
	public bool disableControls = false;
	public bool _disableForce = true;
	public Material[] mats;
	public Renderer rend;

    private PlayerScript S;
    private Transform leftPupilCenter, rightPupilCenter, leftPupil, rightPupil;

	void Awake() {
		rend = GetComponent<Renderer>();
	}

	void setMaterial() {
		if (mats.Length < 2) return;
		rend.sharedMaterial = mats[disableForce?0:1];
	}

	void Start() {
		setMaterial();
        S = PlayerScript.S;
        leftPupilCenter = this.gameObject.transform.Find("Face/Left Eye/PupilCenter");
        rightPupilCenter = this.gameObject.transform.Find("Face/Right Eye/PupilCenter");
    }

    //http://forum.unity3d.com/threads/need-vector3-angle-to-return-a-negtive-or-relative-value.51092/#post-324018
    public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n) {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (!disableForce) {
            float u = Time.time % 1.0f;
            u = Mathf.Sin(2 * Mathf.PI * u);
            float scale = (1 - u) * 0.9f + u * 1.0f;
            if (transform.childCount > 0) {
                transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, scale, 1);
            }
        }
        else
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, .1f, 1);
            }
        }

        if (S) {
            Vector3 leftVector = S.transform.position - leftPupilCenter.position;
            Vector3 rightVector = S.transform.position - rightPupilCenter.position;
            float leftAngle = AngleSigned(leftVector, Vector3.right, Vector3.back);
            float rightAngle = AngleSigned(rightVector, Vector3.right, Vector3.back);
            leftPupilCenter.rotation = Quaternion.AngleAxis(leftAngle, Vector3.forward);
            rightPupilCenter.rotation = Quaternion.AngleAxis(rightAngle, Vector3.forward);
        }

		int iter = 0;
		if (disableControls) return;
		foreach (Touch touch in Input.touches) {
			//http://stackoverflow.com/questions/21409573/how-to-detect-touch-on-a-game-object
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(iter).position );
			RaycastHit hit;

			iter++;

			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				if (Physics.Raycast (ray, out hit) && hit.transform.gameObject == this.gameObject) {
					if (disableForce) {
						touchOn ();
					}
				}
			} else {
				touchOff ();
			}
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
		if (disableControls) return;
		disableForce = !disableForce;
        if (!disableForce) {
            ClickCounter.instance.clickCount++;
            transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, .1f, 1);
        }
    }

	void touchOn() {
		disableForce = false;
		ClickCounter.instance.clickCount++;
	}

	void touchOff() {
		disableForce = true;
	}
}
