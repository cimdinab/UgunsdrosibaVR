using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{

    private Camera _mCamera; //Main camera
    public float mFuseDuration = 3.0f;
    [Tooltip("The event to be called if the fuse was successful")]
    public UnityEvent mSuccessfulEvent;

    [Tooltip("The event to be called if the fuse failed")]
    public UnityEvent mFailureEvent;

    private bool _mFusing = false;
    private bool _mSuccessful = false;

    private float _mFuseTime;
    // Start tiek izsaukts pirms pirmā kadra
    void Start()
    {
        _mCamera = Camera.main;
    }

    // Update tiek izsaukts katru kadru
    void Update()
    {
        if (_mFusing)
        {
            float lElapsedTime = Time.time - _mFuseTime;
            RaycastHit lHit; //raycast rezultāts
            Physics.Raycast(_mCamera.transform.position,
                _mCamera.transform.forward, out lHit); 
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
    {
        _mFusing = true;
        _mFuseTime = Time.time;
    }

    public void OnPointerExit()
    {
        if (!_mSuccessful) //nav successful
            mFailureEvent.Invoke();
        _mFusing = false;
        _mSuccessful = false;
    }
}
