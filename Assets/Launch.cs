using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

    public GameObject bullet;
    public float bulletForce;
    public Transform bulletEmiter;
    public GameObject parent;
    private GameObject Temporary_Bullet_Handler;

    // Use this for initialization
    void Start () {

    }

    void OnEnable()
    {
        IEnumerator coroutine1;
        coroutine1 = CreateBullet();
        StartCoroutine(coroutine1);
    }

    void OnDisable()
    {
        Destroy(Temporary_Bullet_Handler);
    }
	
	// Update is called once per frame
	void Update () {


    }


    IEnumerator DestroyBullet(GameObject aa)
    {
        yield return new WaitForSeconds(2.3f);
        Destroy(aa);

        IEnumerator coroutine1;
        coroutine1 = CreateBullet();
        StartCoroutine(coroutine1);
    }

    IEnumerator CreateBullet()
    {
        Temporary_Bullet_Handler = Instantiate(bullet, bulletEmiter.position, bulletEmiter.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.parent = parent.transform;

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
        Temporary_RigidBody.AddForce(new Vector3(-1.0f, 1.0f, 0f) * bulletForce);

        IEnumerator coroutine;
        coroutine = DestroyBullet(Temporary_Bullet_Handler);
        StartCoroutine(coroutine);

        yield return new WaitForSeconds(0.1f);
    }

}
