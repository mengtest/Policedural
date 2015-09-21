using UnityEngine;
using System.Collections;

public class EnemyBehaviour03 : MonoBehaviour {

	GameObject player;
	GameObject clone;
	public GameObject Bullet;
	public Transform shotSpawn;
	Vector3 actu1;
	Vector3 actu2;
	float shotSpeed =3f;

	public GameObject lifeBar;

	float percent;
	Vector3 newScale;

	// Use this for initialization
	void Start () {
		Invoke ("Shot", shotSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");
		var newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime);//* 8f);
	
	}

	public void Shot(){

		clone = Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation) as GameObject;
		clone.transform.localScale = new Vector3 (1.5f,1.5f, 1.5f);
		actu2 = transform.localEulerAngles;
		actu2.z += 90;
		clone.transform.localEulerAngles = actu2;
		Rigidbody2D bulletRigidbody = clone.GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(clone.transform.right * 75);

		
		Invoke ("Shot", shotSpeed);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "BulletPlayer"  ) {
			newScale = lifeBar.transform.localScale;
			percent = lifeBar.transform.localScale.x;
			percent -=1;
			if(percent <= 0){
				Destroy(transform.parent.gameObject);

				Destroy(collider.gameObject);
			}else{
				newScale.x = percent;
				lifeBar.transform.localScale = newScale;
				//ShowLifeBar();
			}
		}
	}
}
