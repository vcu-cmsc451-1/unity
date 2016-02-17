using UnityEngine;
using System.Collections;

public class pickupObject : MonoBehaviour {
    //GameObject mainCamera;
    public Camera mainCamera;
    GameObject carriedObject;
    GameObject theHaptic;
    SphereManipulator sphereScript;
    bool carryingObject;
    public float distance;
    public float smooth;
    // Use this for initialization
    void Start () {
        theHaptic = GameObject.Find("Falcon");
        sphereScript = theHaptic.GetComponent<SphereManipulator>();
    }

    // Update is called once per frame
    void Update () {
        if(carryingObject)
        {
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }
    }

    void carry(GameObject o)
    {
        //Rigidbody rd = o.GetComponent<Rigidbody>();
        //rd.isKinematic = true;
        o.transform.position = Vector3.Lerp(o.transform.position,mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup()
    {
        if(sphereScript.button_pressed == 0)//if(Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                pickupAble p = hit.collider.GetComponent<pickupAble>();
                if(p != null)
                {
                    Rigidbody rd = p.GetComponent<Rigidbody>();
                    rd.isKinematic = true;
                    carryingObject = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }

    void checkDrop()
    {
        if(sphereScript.button_pressed == 1)//if(Input.GetKeyDown(KeyCode.E))
        {
            dropObject(carriedObject);
        }
    }

    void dropObject(GameObject o)
    {
        //rd.isKinematic = false;
        Rigidbody rd = o.GetComponent<Rigidbody>();
        rd.isKinematic = false;
        carryingObject = false;
        carriedObject = null;

    }

}
