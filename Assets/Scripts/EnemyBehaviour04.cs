using UnityEngine;
using System.Collections;

public class EnemyBehaviour04 : MonoBehaviour {

	GameObject player;
	Vector3 direction1;
	Vector3 direction2;
	float Speed = 0.5f;
	Vector3 speedRotation;
	float sRotation = 1f;
	float distance;
	float step;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		speedRotation = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");
		distance = Vector3.Distance (transform.position, player.transform.position);
		if (distance < 10) {
			direction1 = transform.position;
			direction2 = player.transform.position;
			//direction1.y = constantY;
			step = Speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(direction1, direction2, step);
			
			speedRotation.z += sRotation;
			transform.localEulerAngles = speedRotation;
		}

	}
}
