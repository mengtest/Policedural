using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnableEnemyWithPlayerDistance : MonoBehaviour {

    public float activationDistance = 10.0f;
    WaitForSeconds wait;

	void Start () {
        wait = new WaitForSeconds(2.0f);
        StartCoroutine(CheckIfPlayerNear()); // iniciar coroutina de disparo
    }

    /**
        Esta coroutine comprueba si los enemigos que hay en la lista de enemigos estan cerca o lejos del jugador.
        Si estan cerca son activados, si estan lejos son desactivados
    */
    IEnumerator CheckIfPlayerNear()
    {
        while (true)
        {
            for (int i = 0; i < LevelStorage.Instance.EnemiesList.Count; i++) {
                if (Vector3.Distance(LevelStorage.Instance.EnemiesList[i].transform.position, LevelStorage.Instance.Player.transform.position) < activationDistance)
                {
                    LevelStorage.Instance.EnemiesList[i].SetActive(true);
                }
                else
                {
                    LevelStorage.Instance.EnemiesList[i].SetActive(false);
                }
            }
            yield return wait;
        }
    }
}
