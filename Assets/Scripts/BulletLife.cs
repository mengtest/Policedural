using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {

    public float lifeTime = 2.0f;
    public WaitForSeconds waitLifeTime;

	void OnEnable () {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        waitLifeTime = new WaitForSeconds(lifeTime);
        StartCoroutine(Autodestroy()); // iniciar coroutina de muerte
    }

    IEnumerator Autodestroy(){
        yield return waitLifeTime;
        Debug.Log("Desactivar!");
        gameObject.SetActive(false);
    }
}
