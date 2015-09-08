using UnityEngine;
using System.Collections;

public class LimitController : MonoBehaviour {

	public GameObject particleBullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Bullet"  || collider.gameObject.tag == "BulletPlayer"  ) {
		
			Vector3 positionBlock =collider.gameObject.transform.position;
			Instantiate (particleBullet, positionBlock, Quaternion.identity);


			Destroy(collider.gameObject);
		
		}
	}

	void OnCollisionEnter2D    (Collision2D collision){
		if(collision.gameObject.tag == "Bullet"){
			//Destroy(GetComponent<Collider>());
		}    
	}
}
