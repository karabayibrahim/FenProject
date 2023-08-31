using Sirenix.OdinInspector.Editor.GettingStarted;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class NodeControl : MonoBehaviour
{
    public GameObject myConnectObject;
    public int id;
    private Button myButton;
    [SerializeField] private Sprite recHiglight;
    [SerializeField] private Sprite startSprite;
    [SerializeField] private Image myImage;
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
            //SetNodeHighlight();
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

    //private void OnValidate()
    //{
    //    //myImage = GetComponent<Image>();
    //    /*startSprite=GetComponent<Image>().sprite;*/
    //    /*recHiglight = ImportExample();*/
    //}

    //private void SetNodeHighlight()
    //{
    //   ControlManager.Instance.Mycoroutine = StartCoroutine(NodeHighlight());
    //}

    private IEnumerator NodeHighlight()
    {
        while (true)
        {
            myImage.sprite = recHiglight;
            //myImage.sprite=
            yield return new WaitForSeconds(0.5f);
            myImage.sprite = startSprite;
            //ImageKey.color = startColor;
            yield return new WaitForSeconds(0.5f);
        }

    }
#if UNITY_EDITOR
    [MenuItem("AssetDatabase/LoadAssetExample")]
    private Sprite ImportExample()
    {
        Sprite t = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Projects/F.6.7.1.2/Sprites/recHighlight.png", typeof(Sprite));
        return t;
    }
#endif

}
