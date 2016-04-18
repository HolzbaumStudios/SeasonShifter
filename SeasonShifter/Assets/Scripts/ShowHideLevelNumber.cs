﻿using UnityEngine;
using System.Collections;

public class ShowHideLevelNumber : MonoBehaviour {

    //Variables
    GameObject levelNumberText;

	// Use this for initialization
	void Start () {
        levelNumberText = GameObject.Find("GUI").transform.FindChild("LevelNumber").gameObject;
        StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        levelNumberText.SetActive(false);
    }
}