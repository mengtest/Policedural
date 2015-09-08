using UnityEngine;
using System.Collections;

public class Planet01 : MonoBehaviour {


	Vector3 actu2;
	public float actuValueY = 1f;	
	public float actuValueX = 1f;

	// Use this for initialization
	void Start () {
		actu2 = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if(actuValueY != -1) actu2.y += actuValueY;
		if(actuValueX != -1)actu2.x += actuValueX;
		transform.localEulerAngles = actu2;
	}
}
