using UnityEngine;
using System.Collections;

public class pickupObject : MonoBehaviour {

    /*The lines that are commented as //K are the lines that can be uncommented for keyboard
    implementation. Lines commented //C are lines for the object to be picked up based on location
    of main camera.
    
    The purpose of this script is pickup objects when the middle falcon button is clicked, and then have it move
    around the screen. This script may be attached to any object, however the pickUpAble script must be attached
    to the object you wish to move.
    */

    //C public Camera mainCamera; 

    public GameObject theCursor; //This can be whatever object you wish to cast the ray from
    GameObject carriedObject; 
    GameObject theHaptic;
    SphereManipulator sphereScript;
    bool carryingObject;

    /*
        Ray Length - how far the ray should extend from the GameObject to check for a hit
        Distance - how far you wish the object to 'float' from the GameObject
        Smooth - This is used to prevent very jerky movement when moving the GameObject around
    */
    public float rayLength;
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
        // o.transform.position = Vector3.Lerp(o.transform.position,mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        o.transform.position = Vector3.Lerp(o.transform.position, theCursor.transform.position + theCursor.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup()
    {
        if (sphereScript.button_pressed == 0)//if (Input.GetKeyDown(KeyCode.E))//if(sphereScript.button_pressed == 0)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            //Ray ray = theCursor.
            //Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(theCursor.transform.position, theCursor.transform.forward, out hit, rayLength))//if(Physics.Raycast(ray, out hit))
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
