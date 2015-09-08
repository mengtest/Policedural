using UnityEngine;
using System.Collections;

public class Wheel01 : MonoBehaviour {

	Vector3 actu2;
	float actuValue = 0.1f;

	// Use this for initialization
	void Start () {
		actu2 = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

		actu2.z += actuValue;
		transform.localEulerAngles = actu2;
	}
}
