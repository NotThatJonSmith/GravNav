using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

	public float strengthOfAttraction = 0;
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
        if (disableForce)
        {
            transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, .1f, 1);
        }
        else
        {
            transform.GetChild(0).transform.FindChild("Mouth").transform.localScale = new Vector3(1, 1, 1);
        }
        if (S) {
            Vector3 leftVector = S.transform.position - leftPupilCenter.position;
            Vector3 rightVector = S.transform.position - rightPupilCenter.position;
            float leftAngle = AngleSigned(leftVector, Vector3.right, Vector3.back);
            float rightAngle = AngleSigned(rightVector, Vector3.right, Vector3.back);
            leftPupilCenter.rotation = Quaternion.AngleAxis(leftAngle, Vector3.forward);
            rightPupilCenter.rotation = Quaternion.AngleAxis(rightAngle, Vector3.forward);
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
