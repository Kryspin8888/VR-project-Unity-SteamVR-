using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class PointsCounter : MonoBehaviour
    {
        public Text text;
        public static int red = 0, yellow = 0, green = 0, hit = 0;
    public static float speed = 0.0f;
    public static int pickup = 0;
    public static float distance = 0.0f;
    public static float angle = 0.0f;

    public GameObject longbow;
    public GameObject shortGun;
    public GameObject longGun;
    public GameObject disc;
    public GameObject dart;
    public GameObject squash;
    public GameObject basketball;
    public GameObject targetShield;
    public GameObject targetQuill;

    private string info = "";

    // Use this for initialization
    void Start()
        {

        }

    // Update is called once per frame
    void FixedUpdate()
    {
        info = "";
        if (targetShield.activeSelf)
        {
            info += "Trafienia: " + hit.ToString() + "\n";
            info += "zielony: " + green.ToString() + "\n";
            info += "żółty: " + yellow.ToString() + "\n";
            info += "czerwony: " + red.ToString() + "\n"; 
        }
        if (targetQuill.activeSelf)
        {
            info += "Trafienia: " + hit.ToString() + "\n";
        }
        if (disc.activeSelf)
        {
            info += "Odległość: " + distance.ToString("F2") + " m\n";
            info += "Prędkość: " + speed.ToString() + " km/h\n";
            info += "Kąt rzutu: " + angle.ToString("F2") + " stopni\n";

            if(targetQuill.activeSelf || targetShield.activeSelf)
            {
                targetQuill.SetActive(false);
                targetShield.SetActive(false);
            }
        }
        if (dart.activeSelf)
        {
            info += "Prędkość: " + speed.ToString() + " km/h\n";
        }
        if (squash.activeSelf)
        {
            info += "Odbicia: " + pickup.ToString() + "\n";
            info += "Prędkość: " + speed.ToString() + " km/h\n";

            if (targetQuill.activeSelf || targetShield.activeSelf)
            {
                targetQuill.SetActive(false);
                targetShield.SetActive(false);
            }
        }
        if (basketball.activeSelf)
        {
            info += "Trafienia: " + hit.ToString() + "\n";
            info += "Prędkość: " + speed.ToString() + " km/h\n";

            if (targetQuill.activeSelf || targetShield.activeSelf)
            {
                targetQuill.SetActive(false);
                targetShield.SetActive(false);
            }
        }
        text.text = info;
    }

    public void ResetParameters()
    {
        red = 0;
        yellow = 0;
        green = 0;
        hit = 0;
        speed = 0.0f;
        pickup = 0;
        distance = 0.0f;
        angle = 0.0f;
    }
}