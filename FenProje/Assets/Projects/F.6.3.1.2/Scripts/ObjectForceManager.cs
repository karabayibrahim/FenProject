using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;


public class ObjectForceManager : MonoBehaviour
{
    [SerializeField] private GameObject leftObject;
    [SerializeField] private GameObject rightObject;
    [SerializeField] private GameObject upObject;
    [SerializeField] private GameObject downObject;
    [SerializeField] private TMP_Text resultanttext;
    [SerializeField] private GameObject resultantObj;
    [SerializeField] private UnityEngine.UI.Button moveButton;

    private int leftForces;
    private int rightForces;
    private int upForces;
    private int downForces;
    private int resultantforcehorizontal;
    private int resultantforcevertical;
    private Animator anim;
    private string animTrigger;
    private int animSpeed;
    private int id;
    private int temp0;
    private int temp1;
    private GameObject closeObj1;
    private GameObject closeObj2;

    void Start()
    {
        moveButton.onClick.AddListener(StartAnim);
    }

    private void OnValidate()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetId(int _id)
    {
        id = _id;
    }

    public void LeftValues(int value)
    {
        ValuesHandle(value,leftObject);
    }

    public void RightValues(int value)
    {
        ValuesHandle(value, rightObject);
    }

    public void UpValues(int value)
    {
        ValuesHandle(value, upObject);
    }

    public void DownValues(int value)
    {
        ValuesHandle(value, downObject);
    }
    private void ValuesHandle(int value,GameObject obj)
    {
        switch (value)
        {
            case 0:
                //Debug.Log("0 se�tin");
                break;
            case 1:
                ObjectControl(obj,1);
                //ObjectControl(obj,1);
                //Debug.Log("1 se�tin");
                break;
            case 2:
                ObjectControl(obj,2);
                //ObjectControl(obj, 2);
                //Debug.Log("2 se�tin");
                break;
            case 3:
                ObjectControl(obj,3);
                //ObjectControl(obj,3);
                //Debug.Log("3 se�tin");
                break;
            case 4:
                ObjectControl(obj,4);
                //ObjectControl(obj, 4);
                //Debug.Log("4 se�tin");
                break;
            default:
                //Debug.Log("0 se�tin");
                break;
        }
    }

    //private void ObjectControl(GameObject obj,int force)
    //{
    //    if (obj==leftObject)
    //    {
    //        leftForces += force;
    //        Debug.Log(leftForces);
    //    }
    //    else if (obj==rightObject)
    //    {
    //        rightForces += force;
    //    }
    //    else if (obj=upObject)
    //    {
    //        upForces += force;
    //    }
    //    else if (obj==downObject)
    //    {
    //        downForces += force;
    //    }
    //}

    private void ObjectControl(GameObject mainObj,int force)
    {
        if (mainObj == leftObject || mainObj == rightObject)
        {
            if (mainObj==leftObject)
            {
                leftForces=SetForce(force, leftForces);
            }
            else if (mainObj==rightObject) 
            {
                rightForces = SetForce(force, rightForces);
            }
            resultantforcehorizontal = leftForces - rightForces;
            Debug.Log(resultantforcehorizontal);
            if (resultantforcehorizontal < 0) 
            {
                animTrigger = "Left";
                animSpeed = -resultantforcehorizontal;
                Debug.Log("Sola Haraket");
                resultanttext.text = "Bile�ke Kuvvet:" + " " + (-resultantforcehorizontal).ToString() + "N";
                CloseObjects(leftObject, rightObject);
            }
            else if (resultantforcehorizontal>0)
            {
                animSpeed = resultantforcehorizontal;
                resultanttext.text = "Bile�ke Kuvvet:" + " " + resultantforcehorizontal.ToString() + "N";
                Debug.Log("Sa�a Hareket");
                animTrigger = "Right";
                CloseObjects(leftObject, rightObject);

            }
            else
            {
                resultanttext.text = "Bile�ke Kuvvet:" + " " + resultantforcehorizontal.ToString() + "N";
                Debug.Log("Hareketsiz");
            }
            upObject.SetActive(false);
            downObject.SetActive(false);
        }
        else if (mainObj == upObject || mainObj == downObject)
        {
            if (mainObj==upObject)
            {
                upForces = SetForce(force, upForces);
            }
            else if(mainObj==downObject) 
            {
                downForces = SetForce(force, downForces);
            }
            resultantforcevertical = upForces - downForces;
            Debug.Log(resultantforcevertical);
            if (resultantforcevertical < 0)
            {
                Debug.Log("Yukar� Haraket");
                animTrigger = "Up";
                animSpeed = -resultantforcevertical;
                resultanttext.text = "Bile�ke Kuvvet:" + " " + (-resultantforcevertical).ToString() + "N";
                CloseObjects(upObject, downObject);
            }
            else if (resultantforcevertical > 0)
            {
                resultanttext.text = "Bile�ke Kuvvet:" + " " + resultantforcevertical.ToString() + "N";
                Debug.Log("A�a�� Hareket");
                animTrigger = "Down";
                animSpeed = resultantforcevertical;
                CloseObjects(upObject, downObject);
            }
            else
            {
                resultanttext.text = "Bile�ke Kuvvet:" + " " + resultantforcevertical.ToString() + "N";
                Debug.Log("Hareketsiz");
            }
            leftObject.SetActive(false);
            rightObject.SetActive(false);
        }
    }

    private void StartAnim()
    {
        closeObj1.SetActive(false);
        closeObj2.SetActive(false);
        resultantObj.SetActive(false);
        anim.speed = animSpeed;
        anim.SetTrigger(animTrigger);
    }

    private int SetForce(int _force,int forces)
    {
        if (id == 0)
        {
            if (temp0 != 0)
            {
                forces -= temp0;
            }
            forces += _force;
            temp0 = _force;
        }
        else
        {
            if (temp1 != 0)
            {
                forces -= temp1;
            }
            forces += _force;
            temp1 = _force;
        }
        return forces;
    }

    private void CloseObjects(GameObject obj1,GameObject obj2)
    {
        closeObj1 = obj1;
        closeObj2 = obj2;
    }
}
