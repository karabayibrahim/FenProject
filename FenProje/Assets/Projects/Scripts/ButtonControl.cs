using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;
using Sirenix.OdinInspector;
using UnityEngine.UI;
public class ButtonControl : MonoBehaviour
{

    public string buttonName;
    public Texture buttonTexture;
    public bool conductivityControl;
    public IConductivity conductivity;

    private TextMeshProUGUI UITextMeshPro;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => CircuitManager.Instance.OnSetObject?.Invoke(buttonName,buttonTexture,conductivityControl,conductivity));
    }

    private void OnValidate()
    {

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

    [Button]
    private void SetTexture()
    {
        SetName(buttonName);
        buttonTexture = ImportExample(buttonName);
    }
}
