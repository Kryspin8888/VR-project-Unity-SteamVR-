using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class RuntimeShieldReference : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            if(GameObject.Find("TargetShield") != null)
                this.GetComponent<TargetHitEffect>().targetCollider = GameObject.Find("TargetShield").GetComponent<Collider>();
        }

    }
}
