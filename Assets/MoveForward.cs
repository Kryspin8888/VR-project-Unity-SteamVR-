using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class MoveForward : MonoBehaviour
    {

        public SteamVR_Action_Boolean moveForwardAction;
        public float movementSpeed = 5.0f;
        public Hand leftHand;
        public Hand rightHand;
        public Transform camera1;

        void Update()
        {
            if (moveForwardAction.GetState(leftHand.handType) && !moveForwardAction.GetState(rightHand.handType))
            {
                transform.position += camera1.transform.forward * Time.deltaTime * movementSpeed;
            }
            else if (moveForwardAction.GetState(rightHand.handType) && !moveForwardAction.GetState(leftHand.handType))
            {
                transform.position += camera1.transform.forward * Time.deltaTime * movementSpeed;
            }

        }
    }
}
