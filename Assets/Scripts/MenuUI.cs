﻿using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressPlay(){
		Application.LoadLevel ("MainScene");
	}
}
