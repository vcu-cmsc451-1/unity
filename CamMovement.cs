using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {

    float speed = 3.0f;
    // Vector3 pos = new Vector3(0, 0, 0);
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0.0f, 0.0f, 0.2f);
            //Debug.Log("works");
        }
        else if(Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0.0f, 0.0f, -0.2f);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-0.2f, 0.0f, 0.0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(0.2f, 0.0f, 0.0f);
        }
        else if(Input.GetKey(KeyCode.Z))
        {
            this.transform.position += new Vector3(0.0f, -0.2f, 0.0f);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            this.transform.position += new Vector3(0.0f, 0.2f, 0.0f);
        }

    }
}
