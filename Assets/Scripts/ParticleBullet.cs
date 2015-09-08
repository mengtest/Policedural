using UnityEngine;
using System.Collections;

public class ParticleBullet : MonoBehaviour {
	public float lifeTime = 4f;
	// Use this for initialization
	void Start () {
		//Invoke ("Destroying", lifeTime);
	}
	void Destroying(){
		//Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		if (!GetComponent<ParticleSystem> ().IsAlive())
			Destroy (gameObject);
	}
}
