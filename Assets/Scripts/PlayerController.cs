using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Rigidbody PlayerRigidBody;
    public Transform shotSpawn;
    public GameObject shot;

    float rotationSpeed = 0.05f;//mas pequeño mas lento rota
    float fireRate = 0.85f;
    float nextFire = 0.05f;

    int forceSpeed = 10;

    Vector3 actualRotation = Vector3.zero;
    Vector3 actu2 = Vector3.zero;

    GameObject clone;

    // Use this for initialization
    void Start()
    {
    }
    void FixedUpdate()
    {
    }
    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey("w"))
        {
            PlayerRigidBody.AddForce(new Vector3(0, 0, forceSpeed));
            transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, 180, rotationSpeed), actualRotation.z);
        }
        if (Input.GetKey("d"))
        {
            PlayerRigidBody.AddForce(new Vector3(forceSpeed, 0, 0));
            if (90 > transform.localEulerAngles.y)
            {
                transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, -90, rotationSpeed), actualRotation.z);
            }
            else
            {
                transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, 270, rotationSpeed), actualRotation.z);
            }

        }
        if (Input.GetKey("s"))
        {
            PlayerRigidBody.AddForce(new Vector3(0, 0, -forceSpeed));
            if (transform.localEulerAngles.y > 180)
            {
                transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, 360, rotationSpeed), actualRotation.z);
            }
            else
            {
                transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, 0, rotationSpeed), actualRotation.z);
            }
        }
        if (Input.GetKey("a"))
        {
            PlayerRigidBody.AddForce(new Vector3(-forceSpeed, 0, 0));
            if (transform.localEulerAngles.y > 270)
            {
                transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, 450, rotationSpeed), actualRotation.z);
            }
            else
            {
                transform.localEulerAngles = new Vector3(actualRotation.x, Mathf.Lerp(actualRotation.y, 90, rotationSpeed), actualRotation.z);
            }
        }
    }
}