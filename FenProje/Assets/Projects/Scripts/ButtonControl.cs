using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class ButtonControl : MonoBehaviour
{

    public string buttonName;
    public Texture buttonTexture;
    public bool conductivityControl;
    public IConductivity conductivity;
    private TextMeshProUGUI UITextMeshPro;
    void Start()
    {
        
    }

    private void OnValidate()
    {
        SetName(buttonName);
        buttonTexture=ImportExample(buttonName);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetName(string name)
    {
        UITextMeshPro=GetComponentInChildren<TextMeshProUGUI>();
        UITextMeshPro.text = name;
    }
    [MenuItem("AssetDatabase/LoadAssetExample")]
    private Texture ImportExample(string _buttonName)
    {
        _buttonName = buttonName.Replace(" ", "");
        Texture2D t = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Projects/Sprites/ObjectsSprites/"+_buttonName+".png", typeof(Texture2D));
        return t;
    }


}
