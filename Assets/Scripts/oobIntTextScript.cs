using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class oobIntTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerScript.S)
        {
            GetComponent<Text>().text = PlayerScript.S.gameObject.GetComponent<PlayerScript>().oobTimeInt.ToString();
        }
	}
}
