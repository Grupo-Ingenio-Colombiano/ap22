using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour {

    public Text texto;

    float time;

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        time += (Time.deltaTime - time) * 0.1f;

        float Fps = 1.0f / time;


        texto.text = Fps.ToString("F2");
	}
}
