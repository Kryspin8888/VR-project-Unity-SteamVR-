using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class DistanceAndAngleCalc : MonoBehaviour
    {

        public Transform startPoint;

        // Update is called once per frame
        void FixedUpdate()
        {
            if(this.GetComponent<Rigidbody>().velocity.magnitude > 0.3)
                PointsCounter.distance = (this.transform.position - startPoint.position).magnitude;
        }

        private void OnDetachedFromHand(Hand hand)
        {
            Vector3 vel = this.GetComponent<Rigidbody>().velocity;
            PointsCounter.angle = 90.0f - Vector3.Angle(vel, Vector3.up);
        }


    }
}