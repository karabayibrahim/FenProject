using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControlManager : MonoSingleton<ControlManager>
{
    public bool ControlStatus = false;
    //public Action OnControl;

    public NodeControl FirstSelect = null;
    public NodeControl SecondSelect = null;
    public Connection connection;
    [SerializeField] private Image target;
    [SerializeField] Canvas scaler;
    [SerializeField] private GameObject checkObj;
    [SerializeField] private GameObject crossObj;
    [SerializeField] private List<Connection> connectionsList = new List<Connection>();
    void Start()
    {
        foreach (var item in ConnectionManager.instance.connections)
        {
            if (!item.CompareTag("Target"))
            {
                connectionsList.Add(item);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 position= new Vector2(Input.mousePosition.x * scaler.referenceResolution.x / Screen.width, Input.mousePosition.y * scaler.referenceResolution.y / Screen.height);
        //target.rectTransform.position = Camera.main.ScreenToViewportPoint(position);
        
        DrawConnection(ControlStatus);
    }

    public void SetCorrectControl()
    {
        if (FirstSelect.id == SecondSelect.id && FirstSelect.name != SecondSelect.name)
        {
            FirstSelect.myConnectObject.SetActive(true);
            connectionsList.Remove(FirstSelect.myConnectObject.GetComponent<Connection>());
            ObjectActivetedControl(checkObj, true);
            CompleteControl();
            //Debug.Log("Dogru");
        }
        else
        {
            ObjectActivetedControl(crossObj, true);
            //Debug.Log("Yanlis");
        }
    }

    private void DrawConnection(bool _controlStatus)
    {
        _controlStatus = ControlStatus;
        if (_controlStatus)
        {
            connection.gameObject.SetActive(true);
            connection.target[0] = FirstSelect.GetComponent<Image>().rectTransform;
            connection.target[1] = target.GetComponent<RectTransform>();
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(scaler.transform as RectTransform, Input.mousePosition, scaler.worldCamera, out pos);
            target.rectTransform.position = scaler.transform.TransformPoint(pos);
            ConnectionManager.AddConnection(connection);
        }
        else
        {
            connection.gameObject.SetActive(false);
        }
    }

    private void CompleteControl()
    {
        if (connectionsList.Count<=0)
        {
            Debug.Log("Bitti");
        }
    }

    public void ObjectActivetedControl(GameObject activeObject,bool activecheck)
    {
        activeObject.SetActive(activecheck);
    }
}
