using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinTextScript : MonoBehaviour {

    public string clickText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setText() {
        this.gameObject.GetComponent<Text>().text = clickText + Camera.main.GetComponent<ClickCounter>().clickCount;
    }
}
