using UnityEngine;
using System.Collections;

public class WallsController : MonoBehaviour {

	public GameObject particleBullet;


	void OnTriggerEnter(Collider collider){
		/*if (collider.gameObject.tag == "Bullet"  || collider.gameObject.tag == "BulletPlayer"  ) {
		    
			Vector3 positionBlock =collider.gameObject.transform.position;
			Instantiate (particleBullet, positionBlock, Quaternion.identity);

			Destroy(collider.gameObject);
		
		}*/
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "PlayerBullet"){
            collision.gameObject.SetActive(false);
		}    
	}
}
