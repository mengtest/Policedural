using UnityEngine;
using System.Collections;

public class EnemyBehaviour02 : MonoBehaviour {

	GameObject clone;
	public GameObject Bullet;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;
	Vector3 actu1;
	Vector3 actu2;

	float distance;
	GameObject player;
	bool shooter = true;

	int rotateSpeed = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");
		distance = Vector3.Distance (transform.position, player.transform.position);
		if (distance < 10 && shooter) {
			Invoke ("Shot", 1f);
			shooter=false;
		}
		if (distance < 10) {
			actu1.z += rotateSpeed;
			transform.localEulerAngles = actu1;
		}

	}

	public void Shot(){
		shotBullet (shotSpawn1,90);
		shotBullet (shotSpawn2,0);
		shotBullet (shotSpawn3,270);
		shotBullet (shotSpawn4,180);
		/*
		clone = Instantiate(Bullet, shotSpawn1.position, shotSpawn1.rotation) as GameObject;
		actu2 = transform.localEulerAngles;
		actu2.z += 90;
		clone.transform.localEulerAngles = actu2;
		Rigidbody2D bulletRigidbody = clone.GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(clone.transform.right * 250);
*/

		Invoke ("Shot", 1f);
	}

	private void shotBullet( Transform shotSpawn, int angle){
		clone = Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation) as GameObject;
		actu2 = transform.localEulerAngles;
		actu2.z += angle;
		clone.transform.localEulerAngles = actu2;
		Rigidbody2D bulletRigidbody = clone.GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(clone.transform.right * 250);
	}
}
