using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroLevelTextScript : MonoBehaviour {

    private string[] textStrings = { "Wake up!",
                                    "The fuel line broke and is spewing fumes into the ship!",
                                    "You must've passed out and inhaled a lot of fumes.",
                                    "I look like a llama? That's the fuel leak. It causes visual hallucinations.",
                                    "You might see other strange things...like eyes on planets. Don't worry about them.",
                                    "We'll need to get you home to reverse the side effects of the fuel, but without fuel we can't move our ship.",
                                    "Oh wait! Our gravity field manipulator is still functional, we might be able to use that to navigate.",
                                    "We're so far from home. Let's just focus on getting to the closest warpgate in this sector."};

    public int textIndex = 0;
    public float lastPhraseTime;

	// Use this for initialization
	void Start () {
        lastPhraseTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Time.time - lastPhraseTime > 4f)
        {
            lastPhraseTime = Time.time;
            if(textIndex < textStrings.Length)
            {
                GetComponent<Text>().text = textStrings[textIndex++];
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
	}
}
