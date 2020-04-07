using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool _mMoving = false; //Controls whether or not this object is moving
    private Camera _mCamera; //The main camera
    // Start is called before the first frame update
    void Start()
    {
        _mCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_mMoving)
        {
            RaycastHit lHit; //this stores the result of the raycast
            Physics.Raycast(_mCamera.transform.position, _mCamera.transform.forward, out lHit); //perform a raycast into the scene from the cameras' PoV
            if (lHit.collider != null) //if we hit something
            {
                gameObject.transform.position = lHit.point; //move us there
            }
            else
            {
                gameObject.transform.position = _mCamera.transform.position + _mCamera.transform.forward * 2.0f; //just move us in front of the camera
            }
        }
    }

    public void OnPointerDown() //when the button is pressed down
    {
        _mMoving = true;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void OnPointerUp() //when the button is released
    {
        _mMoving = false;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
