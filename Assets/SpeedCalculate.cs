using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class SpeedCalculate : MonoBehaviour
    {

        // Update is called once per frame
        private void OnDetachedFromHand(Hand hand)
        {

        float vel = this.GetComponent<Rigidbody>().velocity.magnitude;
        PointsCounter.speed = Mathf.Floor(vel * 3.6f);

        }

    }
}