using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CircuitManager : MonoBehaviour
{
    public static CircuitManager instance=null;
    public Action<string,Texture,bool,IConductivity> OnSetObject;
    public Action<bool> OnSetKeyObject;

    [SerializeField] private RawImage CircuitObject;
    [SerializeField] private RawImage Circuit;
    [SerializeField] private RawImage Line;
    [SerializeField] private bool circuitConductivityControl;
    [SerializeField] private bool keyControl;
    [SerializeField] private Texture UnlitLamp;
    [SerializeField] private Texture LitLamp;
    public static CircuitManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<CircuitManager>();
            }
            return instance;
        }
    }
    void Start()
    {
        OnSetObject += SetCurcuitStatus;
        OnSetKeyObject += SetKeyStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCurcuitStatus(string buttonName,Texture objectTexture,bool conductivityControl,IConductivity conductivity)
    {
        CircuitObject.texture = objectTexture;
        circuitConductivityControl = conductivityControl;
    }

    private void SetKeyStatus(bool keyStatus)
    {
        keyControl = keyStatus;
        CurcuitStatus();
    }

    private void CurcuitStatus()
    {
        if (!keyControl && circuitConductivityControl)
        {
            StartCoroutine(TimerCircuitStatus(LitLamp,true));
        }
        else
        {
            StartCoroutine(TimerCircuitStatus(UnlitLamp,false));
        }
    }

    private IEnumerator TimerCircuitStatus(Texture texture,bool status)
    {
        yield return new WaitForSeconds(0.4f);
        Circuit.texture = texture;
        Line.gameObject.SetActive(status);
    }
}
