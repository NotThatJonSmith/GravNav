using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
    public GameObject       poi; //The player ship
    public GameObject[]     panels; //The scrolling foregrounds
    public float            scrollSpeed = -30f;
    //motionMult controls how much panels react to player movement
    public float            motionMult = 0.1f;
    public float            screenWidth = 120;
    public float            screenHeight = 120;

    private float           panelHt; //Height of the panel
    private float           depth; //Depth of panels (pos.z)

	// Use this for initialization
	void Start () {
        panelHt = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;

        //Set initial positions of panels
        panels[0].transform.position = new Vector3(0, 0, depth);
	}
	
	// Update is called once per frame
	void Update () {
        float dY = 0, dX = 0;

        if (poi != null) {
            dX = -poi.GetComponent<Rigidbody>().velocity.x * motionMult;
            dY = -poi.GetComponent<Rigidbody>().velocity.y * motionMult;
        }

        //Position panels[0]
        panels[0].transform.position += new Vector3(dX, dY, 0);

        if (panels[0].transform.position.y <= -screenHeight / 2) {
            panels[0].transform.position += new Vector3(0, screenHeight, 0);
        } else if (panels[0].transform.position.y >= screenHeight / 2) {
            panels[0].transform.position -= new Vector3(0, screenHeight, 0);
        }

        if (panels[0].transform.position.x <= -screenWidth / 2) {
            panels[0].transform.position += new Vector3(screenWidth, 0, 0);
        } else if (panels[0].transform.position.x >= screenWidth / 2) {
            panels[0].transform.position -= new Vector3(screenWidth, 0, 0);
        }
    }
}
