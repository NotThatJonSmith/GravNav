using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    
    public GameObject focus;
    public float stickSpeed;
    private Transform startTransform;

	// Use this for initialization
	void Start () {
        startTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void LateUpdate() {
        startTransform.position = transform.position = focus.transform.position;
        float horizontalRot = Time.deltaTime * stickSpeed * Input.GetAxis("RightHorizontal");
        float verticalRot   = Time.deltaTime * stickSpeed * Input.GetAxis("RightVertical");
        //Rigidbody focusBody = focus.GetComponent<Rigidbody>();
        transform.eulerAngles += new Vector3(verticalRot, horizontalRot, 0);
    }
}
