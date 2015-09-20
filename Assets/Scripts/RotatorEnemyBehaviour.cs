using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (ShipCombatInfo))]
public class RotatorEnemyBehaviour : MonoBehaviour {

    // Public objects
    public float rotationVelocity = 15.0f;
    public GameObject bulletPrefab;

    // Private objects
    GameObject shoot01, shoot02, shoot03, shoot04;
    WaitForSeconds waitBetweenShoots; // Tiempo entre disparos (objeto)
    ObjectsPool bulletsPool;
    ShipCombatInfo shipInfo;


    // Obtain reference to children object and componentes
    void Awake() {
        shoot01 = transform.Find("Shoot01").gameObject;
        shoot02 = transform.Find("Shoot02").gameObject;
        shoot03 = transform.Find("Shoot03").gameObject;
        shoot04 = transform.Find("Shoot04").gameObject;
    }

	// Use this for initialization
	void Start () {
        shipInfo = GetComponent<ShipCombatInfo>();
        bulletsPool = new ObjectsPool(bulletPrefab, transform, true);
        waitBetweenShoots = new WaitForSeconds(shipInfo.TimeBetweenShoots);
        StartCoroutine(ShootCountdown()); // iniciar coroutina de disparo
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotationVelocity * Time.deltaTime); // rotar alrededor del eje UP del modelo
	}

    void OnCollisionEnter(Collision other) {
        // Si lo que ha chocado a sido el jugador debemos hacer que rebote (SIN TESTEAR)
        /*if (other.tag == "Player") { 
            Vector3 direction = other.transform.position - transform.position;
            other.GetComponent<Rigidbody>().velocity += direction.normalized * 5;
        }*/
    }

    // Coroutina que controlar el tiempo entre disparos
    IEnumerator ShootCountdown() {
        while (true) {
            ShootFromShooter(shoot01);
            ShootFromShooter(shoot02);
            ShootFromShooter(shoot03);
            ShootFromShooter(shoot04);
            yield return waitBetweenShoots;
        }
    }

    void ShootFromShooter(GameObject shooter) {
        GameObject b = bulletsPool.GetPooledObject();
        if (b == null) return;
        b.SetActive(true);
        b.transform.position = shooter.transform.position;
        b.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * shipInfo.ShootForce);
    }
}
