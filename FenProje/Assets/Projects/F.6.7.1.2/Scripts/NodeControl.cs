using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class NodeControl : MonoBehaviour
{
    public GameObject myConnectObject;
    public int id;
    private Button myButton;
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(SetControlButton);
    }

    private void SetControlButton()
    {
        if (!ControlManager.Instance.ControlStatus)
        {
            ControlManager.Instance.FirstSelect = this;
            ControlManager.Instance.ControlStatus = true;
        }
        else
        {
            ControlManager.Instance.SecondSelect = this;
            ControlManager.Instance.SetCorrectControl();
            ControlManager.Instance.ControlStatus = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
