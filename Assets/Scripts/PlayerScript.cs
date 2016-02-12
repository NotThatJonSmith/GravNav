using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public GameObject explosionPrefab;
    public GameObject oobCanvasPrefab;

    public GameObject oobCanvas;
    public int oobTimeLimit = 5;
    private float exitTime = 0;
    public int oobTimeLeftInt = 5;

    public static PlayerScript S;
	private Rigidbody rigid;
    public int pickups = 0;
    public int pickupsNeeded = 0;

    private float vertExtent;
    private float horzExtent;

    private float birthTime;
    public bool scaleState;
    public Vector3 startScale = Vector3.zero;
    public Vector3 endScale = Vector3.one;

    void Start() {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        birthTime = Time.time;
        rigid = GetComponent<Rigidbody>();
        scaleState = true;
		if (rigid == null) print("Error: No RigidBody on Player!");
	}
	
	void Awake() {
		if (S) {
			Debug.Log("Multiple players. Error.");
			return;
		}
		S = this;
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude != 0f) {
			transform.rotation = Quaternion.LookRotation(Vector3.forward, rigid.velocity.normalized);
		}	
    }
	
    void OnCollisionEnter(Collision coll){
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            slowTime(2f);
        }

        if (Time.time - birthTime < 1)
        {
            float u = (Time.time - birthTime) % 1.0f;
            transform.localScale = (1 - u) * startScale + u * endScale;
        }
        else if (scaleState)
        { 
            transform.localScale = Vector3.one;
            scaleState = false;
            GetComponent<SphereCollider>().enabled = true;
        }

        if (transform.position.x > horzExtent ||
            transform.position.x < -horzExtent ||
            transform.position.y > vertExtent ||
            transform.position.y < -vertExtent)
        {
            if (exitTime == 0)
            {
                exitTime = Time.time;
                oobCanvas = Instantiate(oobCanvasPrefab) as GameObject;
            }
            else if (Time.time - exitTime <= oobTimeLimit)
            {
                oobTimeLeftInt = oobTimeLimit - Mathf.FloorToInt(Time.time - exitTime);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        } else if(transform.position.x < horzExtent &&
            transform.position.x > -horzExtent &&
            transform.position.y < vertExtent &&
            transform.position.y > -vertExtent)
        {
            Destroy(oobCanvas);
            exitTime = 0;
            oobTimeLeftInt = oobTimeLimit;
        }
    }

    public void win() {
		gameObject.SetActive(false);
	}

	public void slowTime(float timeOfEffect) {
		Invoke("resetTime",timeOfEffect);
		Time.timeScale = .5f;
	}
	
	public void resetTime() {
		Time.timeScale = 1f;
	}
}
