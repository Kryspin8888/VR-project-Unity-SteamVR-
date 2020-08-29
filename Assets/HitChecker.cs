using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour {

    public Transform checker1;
    private bool pom = true;

    void Update()
    {
        Vector3 actualPos = this.transform.position;
        Vector3 checkerPos = checker1.position;

        if (this.GetComponent<Rigidbody>().velocity.y < 0.0f &&
            (actualPos - checkerPos).magnitude <= 0.05f && pom)
        {
            IEnumerator coroutine1;
            coroutine1 = Unlock();
            StartCoroutine(coroutine1);

            pom = false;
        }
    }

    IEnumerator Unlock()
    {
        PointsCounter.hit++;
        yield return new WaitForSeconds(1f);
        pom = true;

    }

}
