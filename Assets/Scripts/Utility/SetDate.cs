using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDate : MonoBehaviour {

    

	// Use this for initialization
	void Start ()
    {
        GetComponentInChildren<Text>().text = System.DateTime.Today.Date.ToString("dd/MM/yyyy");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
