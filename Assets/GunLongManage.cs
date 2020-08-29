using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class GunLongManage : MonoBehaviour
    {

        public GameObject bullet;
        public float bulletForce;
        public Transform bulletEmiter;
        private AudioSource sound;
        public float volumeShot;

        private void Start()
        {
            sound = GetComponent<AudioSource>();
        }



        private void HandAttachedUpdate(Hand hand)
        {
            transform.localRotation = Quaternion.Euler(-90.0f, 0f, -90.0f);

            if (
                (
                    (Input.GetMouseButtonDown(0) || hand.grabPinchAction.GetStateDown(hand.handType)) 
                    && (Input.GetMouseButton(1) || (hand.grabPinchAction.GetState(hand.otherHand.handType) && isInFrontOf(hand.gameObject,hand.otherHand.gameObject) ))
                )
               )
            {
                //The Bullet instantiation happens here.
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(bullet, bulletEmiter.position, bulletEmiter.rotation) as GameObject;

                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
                Temporary_RigidBody.AddForce(bulletEmiter.forward * bulletForce);

                //play sound
                sound.volume = volumeShot;
                sound.Play();

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                IEnumerator coroutine;
                coroutine = DestroyBullet(Temporary_Bullet_Handler);
                StartCoroutine(coroutine);
            }
        }

        IEnumerator DestroyBullet(GameObject aa)
        {
            yield return new WaitForSeconds(5f);
            Destroy(aa);
        }

        bool isInFrontOf(GameObject obj1, GameObject obj2)
        {
            float angel = Vector3.Angle(-obj1.transform.up, obj1.transform.position - obj2.transform.position);
            if (Mathf.Abs(angel) > 135 && Mathf.Abs(angel) < 225)
                return true;
            else return false;
        }
    }
}
