using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum goalMode {FinishLine = 0, Zone};

public class GoalScript : MonoBehaviour {

	public goalMode GoalMode;
	public GameObject goalSpriteRenderer;
	public Sprite[] goalSprites;
	public bool win;
	public GameObject winScreen;

	// Use this for initialization
	void Start () {
		goalSpriteRenderer.GetComponent<SpriteRenderer> ().sprite = goalSprites [(int)GoalMode];
		win = false;

		winScreen.SetActive (false);

        if(PlayerScript.S.GetComponent<PlayerScript>().pickups != PlayerScript.S.GetComponent<PlayerScript>().pickupsNeeded)
        {
            goalSpriteRenderer.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
	}

	// Update is called once per frame
	void Update () {
        if (PlayerScript.S)
        {
            if (PlayerScript.S.GetComponent<PlayerScript>().pickups == PlayerScript.S.GetComponent<PlayerScript>().pickupsNeeded)
            {
                goalSpriteRenderer.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                if (win)
                {
                    winState();
                }
            }
        }
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player") {
			// If finish line, then just use box collider
			if (GoalMode == goalMode.FinishLine) {
				win = isInGoal (coll);
			} 
			// If zone, then calculate to see if in the circle
			else if (GoalMode == goalMode.Zone) {
				win = isInCircle (coll.transform.position);
			}
		}
	}

    //For debug
    void OnTriggerExit(Collider coll)
    {
        win = false;
    }

    // Throw whatever is related to win state here
    void winState() {
		PlayerScript.S.win ();
		winScreen.SetActive(true);
        winScreen.GetComponentInChildren<WinTextScript>().setText();
	}

	bool isInCircle (Vector3 objPos) {
		Vector3 distance = objPos - transform.position;
		distance.x = distance.x / ((transform.localScale.x + 1f)*0.5f);
		distance.y = distance.y / ((transform.localScale.y+ 1f)*0.5f);

		// By "scaling down" manually, it should be back to a unit circle
		if (distance.magnitude <= 1.0f)
			return true;
		else
			return false;
	}

	bool isInGoal(Collider coll) {
		return true;
	}
}
