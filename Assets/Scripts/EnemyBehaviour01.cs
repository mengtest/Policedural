using UnityEngine;
using System.Collections;

public class EnemyBehaviour01 : MonoBehaviour {

	GameObject player;
	Vector3 direction1;
	Vector3 direction2;
	float Speed = 2f;
	public GameObject ParticleEnemy;
	public GameObject Bullet;
	public Transform shotSpawn;
	GameObject clone;
	Vector3 actu2;
	float distance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Invoke ("Shot", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");
		distance = Vector3.Distance (transform.position, player.transform.position);
		if (distance < 10) {
			direction1 = transform.position;
			direction2 = player.transform.position;
			//direction1.y = constantY;
			float step = Speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (direction1, direction2, step);

	
			var newRotation = Quaternion.LookRotation (transform.position - player.transform.position, Vector3.forward);
			newRotation.x = 0.0f;
			newRotation.y = 0.0f;
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 8f);
		}

	}

	void OnCollisionEnter2D    (Collision2D collision){
		if(collision.gameObject.tag == "Bullet"){
			Debug.Log ("OnCollisionEnter2D");
			//Destroy(GetComponent<Collider>());
		}    
	}
	public void Shot(){

		clone = Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation) as GameObject;
		actu2 = transform.localEulerAngles;
		actu2.z += 90;
		clone.transform.localEulerAngles = actu2;
		Rigidbody2D bulletRigidbody = clone.GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(clone.transform.right * 250);
		Invoke ("Shot", 2f);
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "BulletPlayer"  ) {
			
			Vector3 positionBlock = transform.position;
			Instantiate (ParticleEnemy, positionBlock, Quaternion.identity);

			Destroy(gameObject);
			Destroy(collider.gameObject);
			//Vector3 positionBlock =collider.gameObject.transform.position;
			//Instantiate (particleBullet, positionBlock, Quaternion.identity);
			
			
			//Destroy(collider.gameObject);
			
		}
	}
}
