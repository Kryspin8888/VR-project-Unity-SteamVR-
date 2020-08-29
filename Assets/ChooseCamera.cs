using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCamera : MonoBehaviour {

    public Camera VRCamera;
    public Camera FallbackCamera;

	// Use this for initialization
	void Start () {

        if (VRCamera.isActiveAndEnabled)
            this.GetComponent<Canvas>().worldCamera = VRCamera;
        else if (FallbackCamera.isActiveAndEnabled)
            this.GetComponent<Canvas>().worldCamera = FallbackCamera;
    }
	
}
