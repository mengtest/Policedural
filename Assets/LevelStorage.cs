using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelStorage : MonoBehaviour {

    private static LevelStorage instance;
    public static LevelStorage Instance
    {
        get {
            if (instance == null)
                instance = GameObject.FindObjectOfType<LevelStorage>();
            return instance;
        }
    }

    private GameObject player;
    public GameObject Player { get; set; }

    private List<GameObject> enemiesList;
    public List<GameObject> EnemiesList { get { return enemiesList; } }


	// Use this for initialization
	void Start () {
        enemiesList = new List<GameObject>();
	}

}
