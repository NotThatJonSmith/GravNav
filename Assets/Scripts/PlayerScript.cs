using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public GameObject explosionPrefab;
    public int oobTime = 5;
    private float exitTime = 0;
    public int outsideTimeInt = 0;

    public static PlayerScript S;
	private Rigidbody rigid;
    public int pickups = 0;
    public int pickupsNeeded = 0;

    private float vertExtent;
    private float horzExtent;

    void Start() {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        rigid = GetComponent<Rigidbody>();
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

	void Update() {
		if (Input.GetKeyDown(KeyCode.A)) slowTime(2f);
	}
	
    void OnCollisionEnter(Collision coll){
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        if (transform.position.x > horzExtent ||
            transform.position.x < -horzExtent ||
            transform.position.y > vertExtent ||
            transform.position.y < -vertExtent)
        {
            if (exitTime == 0)
            {
                exitTime = Time.time;
            }
            else if (Time.time - exitTime <= oobTime)
            {
                outsideTimeInt = oobTime - Mathf.FloorToInt(Time.time - exitTime);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        } else if(transform.position.x > horzExtent &&
            transform.position.x > -horzExtent &&
            transform.position.y < vertExtent &&
            transform.position.y > -vertExtent)
        {
            exitTime = 0;
            outsideTimeInt = oobTime;
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
