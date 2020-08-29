using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewDart : MonoBehaviour {

    private Vector3 tempPos;
    private Quaternion tempRot;
    public GameObject parent;
    private GameObject Temporary_Bullet_Handler;
    private bool one = true;

    // Use this for initialization
    void Start () {

        tempPos = this.transform.position;
        tempRot = this.transform.rotation;

    }

	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 actualPos = this.transform.position;
        if((actualPos - tempPos).magnitude  >= 0.25f && one)
        {
            Temporary_Bullet_Handler = Instantiate(this.gameObject, tempPos, tempRot) as GameObject;
            Temporary_Bullet_Handler.GetComponent<Rigidbody>().isKinematic = false;
            Temporary_Bullet_Handler.transform.parent = parent.transform;
            one = false;
        }

        else if (!one)
            this.GetComponent<CreateNewDart>().enabled = false;
    }

}
