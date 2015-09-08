using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D PlayerRigidBody;
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
			PlayerRigidBody.AddForce(new Vector2 (0,5));

			if(transform.localEulerAngles.z == 0 ){	
				 
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.z > 0 && transform.localEulerAngles.z <= 180 ){	// 1 cuadrante
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.z > 358 ){ // 2 y 3 cuadrante
				actualRotation.z = 0;
				transform.localEulerAngles = actualRotation;
			}else{
				if( transform.localEulerAngles.z > 180 ){
					actualRotation.z = actualRotation.z + rotationSpeed;
					transform.localEulerAngles = actualRotation;	
				}
			}
		}

		if(Input.GetKey("d")){
			PlayerRigidBody.AddForce(new Vector2 (5,0));

			if(transform.localEulerAngles.z == 270 ){	
				
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.z > 270 && transform.localEulerAngles.z < 360 ){	// 1 cuadrante
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.z < 270 && transform.localEulerAngles.z >= 90){ // 2 y 3 cuadrante
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.z < 90 && transform.localEulerAngles.z > 0.5 ){
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.z < 0.5 ){
				actualRotation.z = 358;
				transform.localEulerAngles = actualRotation;
			}
		}
	
		if(Input.GetKey("s")){
			PlayerRigidBody.AddForce(new Vector2 (0,-5));

			if(transform.localEulerAngles.z == 180 ){	
				
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.z >= 0 && transform.localEulerAngles.z < 180 ){	// 1 cuadrante
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.z > 180 ){ // 2 y 3 cuadrante
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
		}

		if(Input.GetKey("a")){
			PlayerRigidBody.AddForce(new Vector2 (-5,0));

			if(transform.localEulerAngles.z == 90 ){	
			
			}
			if(transform.localEulerAngles.z<0){
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(  transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 90 ){	// 1 cuadrante
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if(transform.localEulerAngles.z <= 270 && transform.localEulerAngles.z > 90){ // 2 y 3 cuadrante
				actualRotation.z = actualRotation.z - rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.z == 0 ){
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
			if( transform.localEulerAngles.z > 270 ){
				actualRotation.z = actualRotation.z + rotationSpeed;
				transform.localEulerAngles = actualRotation;
			}
		}
	}
}