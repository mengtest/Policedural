using UnityEngine;
using System.Collections;

public class SplashScreenLoader : MonoBehaviour {

    public float delayTime = 3;
    public bool done = false;

    float timer;

	// Use this for initialization
	void Start () {
        timer = delayTime;
        StartCoroutine("Loader");
	}
	
	// Update is called once per frame
	void Update () {
        

        if (timer > 0){
            timer -= Time.deltaTime;
            return;
        }

        else { Application.LoadLevel(1); } //Debug Line

        if (done)
            Application.LoadLevel(1);
    }

    IEnumerator Loader() {
        //Do something here


        //some yield operation until it has completed
        yield return null;

        //if the we did what we wanted and got it all done without error
///////////////////////////////////////// done=true;
    }
}
