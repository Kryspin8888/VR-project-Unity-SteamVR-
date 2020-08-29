using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour {

    private Button button;
    private Color startColor;
    public GameObject activity;

    private void Start()
    {
        button = this.GetComponent<Button>();
        startColor = button.colors.normalColor;
    }
    public void FixedUpdate()
    {
        if (activity.activeSelf)
        {
            var colors = button.colors;
            colors.normalColor = Color.green;
            button.colors = colors;
        }

        else
        {
            var colors = button.colors;
            colors.normalColor = startColor;
            button.colors = colors;
        }
    }
}
