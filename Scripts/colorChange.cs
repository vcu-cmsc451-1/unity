using UnityEngine;
using System.Collections;

public class colorChange : MonoBehaviour {
    public Color colorStart = Color.white;
    public Color colorButtonPress = Color.red;
    public Renderer rend;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();

    }



    // Update is called once per frame
    void Update () {
        GameObject theHaptic = GameObject.Find("Falcon");
        SphereManipulator sphereScript = theHaptic.GetComponent<SphereManipulator>();
        if(sphereScript.button_pressed == 1)
        {
            this.rend.material.color = Color.red;
        }
    }
}
