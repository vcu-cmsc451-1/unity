using UnityEngine;
using System.Collections;

public class pickupObject_Camera_Mouse : MonoBehaviour
{

    /*The lines that are commented as //K are the lines that can be uncommented for keyboard
    implementation. Lines commented //C are lines for the object to be picked up based on location
    of main camera.
    
    The purpose of this script is pickup objects when the middle falcon button is clicked, and then have it move
    around the screen. This script may be attached to any object, however the pickUpAble script must be attached
    to the object you wish to move.
    */

    public Vector3 lastObjectPosition = new Vector3(0, 0, 0);
    public Vector3 changeObjectPosition = new Vector3(0, 0, 0);
    public Vector3 test = new Vector3(2, 2, 2);
    public GameObject throwO;
    public Rigidbody rb;
    public float thrust;

    public Camera mainCamera; 

    //public GameObject theCursor; //This can be whatever object you wish to cast the ray from
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
    void Start()
    {
        rb = throwO.GetComponent<Rigidbody>();
        //theHaptic = GameObject.Find("Falcon");
        //sphereScript = theHaptic.GetComponent<SphereManipulator>();
    }

    // Update is called once per frame
    void Update()
    {
 
        if (carryingObject)
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
        o.transform.position = Vector3.Lerp(o.transform.position,mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        //o.transform.position = Vector3.Lerp(o.transform.position, theCursor.transform.position + theCursor.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup()
    {
        if(Input.GetMouseButton(0))//if (Input.GetKeyDown(KeyCode.E))//if(sphereScript.button_pressed == 0)
        {
            lastObjectPosition = throwO.transform.position;
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            //Ray ray = theCursor.
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                pickupAble p = hit.collider.GetComponent<pickupAble>();
                if (p != null)
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
        if(Input.GetMouseButtonUp(0))//if(Input.GetKeyDown(KeyCode.E))
        {
            //dropObject(carriedObject);
            Rigidbody rd = carriedObject.GetComponent<Rigidbody>();
            rd.isKinematic = false;
            carryingObject = false;
            carriedObject = null;
            changeObjectPosition = throwO.transform.position - lastObjectPosition;
                //Debug.Log("Change in X: " + changePosition.x);
                //Debug.Log("Change in Y: " + changePosition.y);

                rb.AddForce(changeObjectPosition * thrust);
                //lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           // }
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
