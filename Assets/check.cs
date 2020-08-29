using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour {

    public GameObject obj2;
	
	// Update is called once per frame
	void Update () {

        float angel = Vector3.Angle(transform.forward, transform.position - obj2.transform.position);
        if(Mathf.Abs(angel) > 150 && Mathf.Abs(angel) < 210)
         Debug.Log("target is in front of me");
        if (Mathf.Abs(angel) < 30 || Mathf.Abs(angel) > 330)
            Debug.Log("target is behind me");
    }
}
