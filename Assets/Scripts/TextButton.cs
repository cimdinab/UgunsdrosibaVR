using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TextButton : MonoBehaviour
{
    public float mFuseDuration = 3.0f;
    [Tooltip("The event to be called if the fuse was successful")]
    public UnityEvent mSuccessfulEvent;

    [Tooltip("The event to be called if the fuse failed")]
    public UnityEvent mFailureEvent;

    private bool _mFusing = false;
    private bool _mSuccessful = false;

    private float _mFuseTime;

    //public GameObject daba;

   // private TextMeshProUGUI tmpObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_mFusing)
        {
            float lElapsedTime = Time.time - _mFuseTime; //current time - start time
            if (lElapsedTime >= mFuseDuration) //if enough time has passed...
            {
                _mSuccessful = true; //We're good
                _mFusing = false;
                mSuccessfulEvent.Invoke();
            }
            else //Not enough time has passed
            {
                gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 0, 255);
                //This results in a value between 0 and 1
            }
        }
    }

    public void OnPointerEnter()
    {
        //gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        _mFusing = true;
        _mFuseTime = Time.time;
    }

    public void OnPointerExit()
    {
        if (!_mSuccessful) //not successful
            mFailureEvent.Invoke();
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        _mFusing = false;
        _mSuccessful = false;
    }
}
