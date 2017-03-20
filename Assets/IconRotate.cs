using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRotate : MonoBehaviour {
    	
	
	void Update () {
        if (transform.rotation != Quaternion.identity)
            transform.rotation = Quaternion.identity;
	}
}
