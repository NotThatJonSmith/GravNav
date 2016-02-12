using UnityEngine;
using System.Collections;

public class ParticleFieldController : MonoBehaviour {

	public GameObject particlePrefab;
	public int particleCount = 100;
	public GameObject[] particles;

	void Start() {
		particles = new GameObject[particleCount];
	}

	void Update() {
		for (int i = 0; i < particles.Length; i++) {
			if (particles[i] == null)
				particles[i] = genParticle();
		}
	}
	
	public GameObject genParticle() {
		//http://answers.unity3d.com/questions/501893/calculating-2d-camera-bounds.html
		float vertExtent = Camera.main.orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		float randX = Random.Range(-horzExtent, horzExtent);
		float randY = Random.Range(-vertExtent, vertExtent);
		Vector3 pos = new Vector3(randX, randY, 0f);
		GameObject go = Instantiate(particlePrefab, pos, Quaternion.identity) as GameObject;
		go.transform.parent = gameObject.transform;
		return go;
	}
}
