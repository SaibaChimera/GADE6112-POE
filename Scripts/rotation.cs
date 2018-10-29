using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (transform.position.x < 11)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
