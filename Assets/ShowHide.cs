using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour {

    public void ShowOrHide()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
           
        }
        else
        {
            gameObject.SetActive(true);

        }
    }
}
