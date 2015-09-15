using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotatorEnemyBehaviour : MonoBehaviour {

    // Public objects
    public float RotationVelocity = 15.0f;
    public float ShootingSpeed = 1.0f; // Tiempo entre disparos
    public GameObject Bullet;

    // Private objects
    GameObject shoot01, shoot02, shoot03, shoot04;
    WaitForSeconds waitBetweenShoots; // Tiempo entre disparos (objeto)
    int pooledBulletsAmount = 10; // Tamaño de la pool de bullets
    List<GameObject> bulletsPool;


    // Obtain reference to children object and componentes
    void Awake() {
        shoot01 = transform.Find("Shoot01").gameObject;
        shoot02 = transform.Find("Shoot02").gameObject;
        shoot03 = transform.Find("Shoot03").gameObject;
        shoot04 = transform.Find("Shoot04").gameObject;
    }

	// Use this for initialization
	void Start () {
        // Inicializar pool de bullets
        /*bulletsPool = new List<GameObject>();
        for (int i = 0; i < pooledBulletsAmount; i++) {
            GameObject b = (GameObject)Instantiate(Bullet);
            bulletsPool.Add(b);
        }*/


        waitBetweenShoots = new WaitForSeconds(ShootingSpeed);
        StartCoroutine(ShootCountdown());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, RotationVelocity * Time.deltaTime); // rotar alrededor del eje UP del modelo
	}

    void OnTriggerEnter(Collider other) {
        // Si lo que ha chocado a sido el jugador debemos hacer que rebote (SIN TESTEAR)
        if (other.tag == "Player") { 
            Vector3 direction = other.transform.position - transform.position;
            other.GetComponent<Rigidbody>().velocity += direction.normalized * 5;
        }
    }

    // Shoot
    IEnumerator ShootCountdown() {
        while (true) {
            Shoot();
            yield return waitBetweenShoots;
        }
    }

    void Shoot() {

    }
}
