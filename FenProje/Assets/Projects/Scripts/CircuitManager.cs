using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector.Editor;

public class CircuitManager : MonoBehaviour
{
    public static CircuitManager instance=null;
    public Action<string,Texture,bool,IConductivity> OnSetObject;
    public Action<bool> OnSetObjectForKey;
    public Action<bool> OnSetKeyObject;
    public KeyButtonControl KeyButtonControl;

    [SerializeField] private RawImage CircuitObject;
    [SerializeField] private RawImage Circuit;
    [SerializeField] private RawImage Line;
    [SerializeField] private bool circuitConductivityControl;
    [SerializeField] private bool keyControl;
    [SerializeField] private Texture UnlitLamp;
    [SerializeField] private Texture LitLamp;
    [SerializeField] private TextMeshProUGUI NotificationText;
    [SerializeField] private List<UnityEngine.UIElements.Image> ImagesKey = new List<UnityEngine.UIElements.Image>();

    private IConductivity circuitConductivityType;
    private string buttonNameCircuit;
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
        OnSetObjectForKey += SetKeyStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCurcuitStatus(string buttonName,Texture objectTexture,bool conductivityControl,IConductivity conductivity)
    {
        CircuitObject.texture = objectTexture;
        circuitConductivityControl = conductivityControl;
        circuitConductivityType = conductivity;
        buttonNameCircuit = buttonName;
        
    }

    private void SetKeyStatus(bool keyStatus)
    {
        keyStatus = KeyButtonControl.MyStatus;
        keyControl = keyStatus;
        CurcuitStatus();
    }

    private void CurcuitStatus()
    {
        if (!keyControl && circuitConductivityControl)
        {
            StartCoroutine(TimerCircuitStatus(LitLamp,true));
            SetNotification(NotificationText,buttonNameCircuit,circuitConductivityType);
        }
        else if (!keyControl && !circuitConductivityControl)
        {
            SetNotification(NotificationText, buttonNameCircuit, circuitConductivityType);
        }
        else
        {
            if (!keyControl)
            {
                StartCoroutine(TimerCircuitStatus(UnlitLamp, false));
                SetNotification(NotificationText, buttonNameCircuit, circuitConductivityType);
            }
            else
            {
                StartCoroutine(TimerCircuitStatus(UnlitLamp, false));
            }
        }
    }

    private IEnumerator TimerCircuitStatus(Texture texture,bool status)
    {
        yield return new WaitForSeconds(0.4f);
        Circuit.texture = texture;
        Line.gameObject.SetActive(status);
    }

    private void SetNotification(TextMeshProUGUI textNot, string buttonName,IConductivity type)
    {
        switch (type)
        {
            case IConductivity.NONE:
                textNot.text = "Devreye bir obje ekleyiniz.";
                // code block
                break;
            case IConductivity.SOLIDCONDUCTOR:
                textNot.text = $"'{buttonName}'"+" "+"katý bir iletkendir.";
                // code block
                break;
            case IConductivity.SOLIDINSULATION:
                textNot.text = $"'{buttonName}'" + " " + "katý bir yalýtkandýr.";
                // code block
                break;
            case IConductivity.LIQUIDCONTUCTOR:
                textNot.text = $"'{buttonName}'" + " " + "sývý bir iletkendir.";
                // code block
                break;
            case IConductivity.LIQUIDINSULANT:
                textNot.text = $"'{buttonName}'" + " " + "sývý bir yalýtkandýr.";
                // code block
                break;
            default:
                textNot.text = "";
                // code block
                break;
        }
    }
}
