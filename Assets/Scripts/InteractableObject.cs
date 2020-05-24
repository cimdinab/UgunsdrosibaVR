using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{

    private Camera _mCamera; //The main camera
    public float mFuseDuration = 3.0f;
    [Tooltip("The event to be called if the fuse was successful")]
    public UnityEvent mSuccessfulEvent;

    [Tooltip("The event to be called if the fuse failed")]
    public UnityEvent mFailureEvent;

    private bool _mFusing = false;
    private bool _mSuccessful = false;

    private float _mFuseTime;
    // Start is called before the first frame update
    void Start()
    {
        _mCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_mFusing)
        {
            float lElapsedTime = Time.time - _mFuseTime;
            RaycastHit lHit; //this stores the result of the raycast
            Physics.Raycast(_mCamera.transform.position,
                _mCamera.transform.forward, out lHit); 
            //perform a raycast into the scene from the cameras' PoV
            if (lElapsedTime >= mFuseDuration) 
                //ja pietiekami ilgs laiks ir pagājis...
            {
                _mSuccessful = true; //ir successful
                _mFusing = false;
                mSuccessfulEvent.Invoke();
            }
            else //vēl nav pagājis pietiekami ilgs laiks
            {

            }
        }
    }

    public void OnPointerEnter() 
        //when the button is pressed down
    {
        _mFusing = true;
        _mFuseTime = Time.time;
    }

    public void OnPointerExit()
        //when the button is released
    {
        if (!_mSuccessful) //nav successful
            mFailureEvent.Invoke();
        _mFusing = false;
        _mSuccessful = false;
    }
}
