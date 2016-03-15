using UnityEngine;
using System.Collections;

public class throwObject : MonoBehaviour {

    //public Vector3 lastPosition = new Vector3(0, 0, 0);
    public Vector3 lastObjectPosition = new Vector3(0, 0, 0);
    public Vector3 changeObjectPosition = new Vector3(0, 0, 0);
    public Vector3 test = new Vector3(2, 2, 2);
    public GameObject throwO;
    public Rigidbody rb;
    public float thrust;
    //public Camera;
    
	// Use this for initialization
	void Start () {
        //lastObjectPosition = new Vector3(0, 0, 0);
        //changePosition = new Vector3(0, 0, 0);
        rb = throwO.GetComponent<Rigidbody>();
}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(0))
        {
            //lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastObjectPosition = throwO.transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            changeObjectPosition = throwO.transform.position - lastObjectPosition;
            //Debug.Log("Change in X: " + changePosition.x);
            //Debug.Log("Change in Y: " + changePosition.y);

            rb.AddForce(changeObjectPosition * thrust);
            //lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                 
        }
	}
}
