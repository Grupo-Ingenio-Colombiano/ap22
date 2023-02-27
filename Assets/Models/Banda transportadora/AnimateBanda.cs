using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBanda : MonoBehaviour {


    Material mat;

    float x = 0;

	// Use this for initialization
	void Start ()
    {
        mat = GetComponent<Renderer>().material;
	}

    private void FixedUpdate()
    {
        x += 0.0077f;

        if (x > 10000f)
        {
            x = 0;
        }

        Vector2 v = new Vector2(x,0);

        mat.mainTextureOffset = v;
    }
}
