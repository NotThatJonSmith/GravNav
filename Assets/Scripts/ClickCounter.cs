using UnityEngine;
using System.Collections;

public class ClickCounter : MonoBehaviour {

    public int clickCount;

    public static ClickCounter instance;

	// Use this for initialization
	void Start () {
        clickCount = 0;
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
