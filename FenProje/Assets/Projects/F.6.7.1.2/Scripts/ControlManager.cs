using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControlManager : MonoSingleton<ControlManager>
{
    public bool ControlStatus=false;
    //public Action OnControl;

    public NodeControl FirstSelect = null;
    public NodeControl SecondSelect = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCorrectControl()
    {
        if (FirstSelect.id == SecondSelect.id&&FirstSelect.name!=SecondSelect.name)
        {
            FirstSelect.myConnectObject.SetActive(true);
            Debug.Log("Doðru");
        }
        else
        {
            Debug.Log("Yanlýþ");
        }
    }
}
