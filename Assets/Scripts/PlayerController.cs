using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody PlayerRigidBody;
	float rotationSpeed = 3;
	Vector3 actualRotation = Vector3.zero;


	//public float speed;
	//public float tilt;
	//public Boundary boundary;
	
	public GameObject shot;
	//public Transform shotSpawn;
	float fireRate = 0.85f;
	
	private float nextFire=0.05f;
	public Transform shotSpawn;
	GameObject clone;
	Vector3 actu2;

	int forceSpeed=10;


	// Use this for initialization
	void Start () {
	}
	void FixedUpdate ()
	{

	}
	// Update is called once per frame
	void Update () {

		actualRotation = transform.localEulerAngles;

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			actu2 = actualRotation;
			actu2.z += 90;
			clone.transform.localEulerAngles = actu2;

			Rigidbody2D bulletRigidbody = clone.GetComponent<Rigidbody2D>();
			bulletRigidbody.AddForce(clone.transform.right * 750);

		}
		if (Input.GetKey ("w")) {
			PlayerRigidBody.AddForce(new Vector3 (0,0,forceSpeed));

			if(transform.localEulerAngles.y== 180 ){	
				
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.y>= 0 && transform.localEulerAngles.y< 180 ){	// 1 cuadrante
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.y> 180 ){ // 2 y 3 cuadrante
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
		}

		if(Input.GetKey("d")){
			PlayerRigidBody.AddForce(new Vector3 (forceSpeed,0,0));

			if(transform.localEulerAngles.y== 270 ){	
				
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.y> 270 && transform.localEulerAngles.y< 360 ){	// 1 cuadrante
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.y< 270 && transform.localEulerAngles.y>= 90){ // 2 y 3 cuadrante
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.y< 90 && transform.localEulerAngles.y> 0.5 ){
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.y< 0.5 ){
				actualRotation.y = 358;
				transform.localEulerAngles = actualRotation;
			}
		}
	
		if(Input.GetKey("s")){
			PlayerRigidBody.AddForce(new Vector3 (0,0,-forceSpeed));

		

			if(transform.localEulerAngles.y== 0 ){	
				
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.y> 0 && transform.localEulerAngles.y<= 180 ){	// 1 cuadrante
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.y> 358 ){ // 2 y 3 cuadrante
				actualRotation.y = 0;
				transform.localEulerAngles = actualRotation;
			}else{
				if( transform.localEulerAngles.y> 180 ){
					actualRotation.y = actualRotation.y + rotationSpeed;
					transform.localEulerAngles = actualRotation;	
				}
			}
		}

		if(Input.GetKey("a")){
			PlayerRigidBody.AddForce(new Vector3 (-forceSpeed,0,0));

			if(transform.localEulerAngles.y== 90 ){	
			
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.y> 0 && transform.localEulerAngles.y< 90 ){	// 1 cuadrante
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.y<= 270 && transform.localEulerAngles.y> 90){ // 2 y 3 cuadrante
				actualRotation.y = actualRotation.y - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.y== 0 ){
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.y> 270 ){
				actualRotation.y = actualRotation.y + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
		}
	}
}