using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndSpeedCalculate : MonoBehaviour {

    public float hitForce = 10.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            PointsCounter.pickup++;

            IEnumerator coroutine1;
            coroutine1 = SpeedCalc();
            StartCoroutine(coroutine1);

            this.GetComponent<Rigidbody>().AddForce(Vector3.forward * hitForce);
        }
    }

    IEnumerator SpeedCalc()
    {

        float vel = this.GetComponent<Rigidbody>().velocity.magnitude;
        PointsCounter.speed = Mathf.Ceil(vel * 3.6f);

        yield return new WaitForSeconds(0.1f);

    }

   
}
