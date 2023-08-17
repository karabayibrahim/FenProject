using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
//using UnityEngine.UIElements;
using Sirenix.OdinInspector;
public class KeyButtonControl : MonoBehaviour
{
    private bool myStatus = true;
    private Button myButton;
    private Animator myAnimator;
    private Color startColor;
    private Coroutine myCoroutine;
    [SerializeField] private Color endColor;
    [SerializeField] private Color closeColor;
    [SerializeField] private Image ImageKey;

    public Action<bool> OnChangeKeyState;
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
        OnChangeKeyState?.Invoke(MyStatus);
        if (MyStatus)
        {
            KeyHighlight();
        }
        else
        {
            StopCoroutine(myCoroutine);
            ImageKey.color= closeColor;
        }
        myAnimator.SetBool("KeyStatus",MyStatus);
    }

    void Start()
    {
        startColor = ImageKey.color;
        myButton = GetComponent<Button>();
        myAnimator = GetComponent<Animator>();
        CircuitManager.Instance.OnSetObjectForKey += SetObjectKeyStatus;
        myButton.onClick.AddListener(SetButtonStatus);
        myButton.onClick.AddListener(() => CircuitManager.Instance.OnSetKeyObject?.Invoke(MyStatus));
        if (MyStatus)
        {
            KeyHighlight();
        }
        else
        {
            StopCoroutine(myCoroutine);
        }
    }

    private void SetButtonStatus()
    {
        if (MyStatus) 
        {
            MyStatus = false;
        }
        else 
        {
            MyStatus = true;
        }
    }

    private void SetObjectKeyStatus()
    {
        MyStatus = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void KeyHighlight()
    {
        myCoroutine=StartCoroutine(TimerKeyHighlight());
    }

    private IEnumerator TimerKeyHighlight()
    {
        while (true)
        {
            ImageKey.color = endColor;
            yield return new WaitForSeconds(1f);
            ImageKey.color = startColor;
            yield return new WaitForSeconds(1f);
        }

    }
}
