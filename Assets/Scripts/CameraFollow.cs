using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//public GameObject Triangulo;
	float distance = 2;
	Vector3 temporalPlayer = Vector3.zero;


	float interpVelocity;

	GameObject target;
	Vector3 offset = new Vector3 (0, 0, 0);
	Vector3 targetPos;
	bool firsTime = true;
	int alturaCamara = 20;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Player");
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (target)
		{
			if(firsTime){
				Vector3 firstTime = target.transform.position;
				firstTime.y = alturaCamara;
				transform.position=firstTime;
				firsTime=false;
			}
			Vector3 posNoY = transform.position;
			posNoY.y = target.transform.position.y;
			Vector3 targetDirection = (target.transform.position - posNoY);
			interpVelocity = targetDirection.magnitude * 6f;
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			/*  Para limitar los ejes de la camara, que la cmara no siga a la nave a partir de las medidas siguientes */
			//float camX = Mathf.Clamp(targetPos.x, -2.4f, 2.4f);
			//float camY = Mathf.Clamp(targetPos.y, -6.92f, 6.92f);
			//transform.position = new Vector3(camX, camY, transform.position.z);

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
		}

	}
}
