using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Autodestroy",5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Autodestroy(){
		Destroy (this.gameObject);
	}
}
