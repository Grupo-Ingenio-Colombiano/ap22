
using UnityEngine;

public class PreventDestroy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
	
	
}
