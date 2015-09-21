using UnityEngine;
using System.Collections;

//public class IATools : MonoBehaviour {
public class IATools {

    private IATools _instance;
    public static IATools Instance
    {
        get {
            if (_instance == null)
                _instance = new IATools();
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
