using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBall : MonoBehaviour {

    public Transform racket;
    public GameObject ball;
    private Vector3 tempPos;
    public float ballForce;
    public GameObject parent;
    bool one = true;

    // Use this for initialization
    void Start()
    {

        tempPos = racket.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 actualPos = racket.position;
        if ((actualPos - tempPos).magnitude >= 0.7f && one)
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(ball, this.transform.position, this.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.parent = parent.transform;

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
            Temporary_RigidBody.AddForce(new Vector3(1.0f, 0.0f, 1.0f) * ballForce);
            one = false;
        }

        if (!one && (actualPos - tempPos).magnitude <= 0.7f)
            one = true;
    }
}
