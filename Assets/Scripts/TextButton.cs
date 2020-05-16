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

    // Start tiek izsaukts pirms pirmā kadra atjaunošanas
    void Start()
    {

    }

    // Update tiek izsaukts vienu reizi katrā kadrā
    void Update()
    {
        if (_mFusing)
        {
            float lElapsedTime = Time.time - _mFuseTime; //pašreizējais laiks - starta laiks
            if (lElapsedTime >= mFuseDuration) //ja pietiekami ilgs laiks ir pagājis...
            {
                _mSuccessful = true; //ir successful
                _mFusing = false;
                mSuccessfulEvent.Invoke();
            }
            else //vēl nav pagājis pietiekami ilgs laiks
            {
                gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 0, 255);
                //objekta krāsa ir dzeltena
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
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        _mFusing = false;
        _mSuccessful = false;
    }
}
