﻿using UnityEngine;
using System.Collections;

public class floorFlame : MonoBehaviour {
    float destroyTimer = 10f;
	// Use this for initialization
	void Awake () {
        Destroy(this.gameObject, destroyTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
