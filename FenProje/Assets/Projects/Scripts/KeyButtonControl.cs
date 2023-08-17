using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonControl : MonoBehaviour
{
    private bool myStatus = true;
    private Button myButton;
    private Animator myAnimator;

    public bool MyStatus 
    {
        get { return myStatus;}
        set
        {
            if (MyStatus == value)
            {
                return;
            }
            myStatus = value;
            OnStateChanged();
        }
    }

    private void OnStateChanged()
    {
        myAnimator.SetBool("KeyStatus",MyStatus);
        Debug.Log(MyStatus);
    }

    void Start()
    {
        myButton = GetComponent<Button>();
        myAnimator = GetComponent<Animator>();
        myButton.onClick.AddListener(SetButtonStatus);
        myButton.onClick.AddListener(() => CircuitManager.Instance.OnSetKeyObject?.Invoke(MyStatus));
    }

    private void SetButtonStatus()
    {
        if (MyStatus) { MyStatus = false;}
        else { MyStatus = true;}
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
