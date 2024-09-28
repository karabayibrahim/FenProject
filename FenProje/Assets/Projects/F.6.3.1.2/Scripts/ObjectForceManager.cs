using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;


public class ObjectForceManager : MonoBehaviour
{
    [SerializeField] private GameObject leftObject;
    [SerializeField] private GameObject leftIcon;
    [SerializeField] private GameObject rightObject;
    [SerializeField] private GameObject rightIcon;
    [SerializeField] private GameObject upObject;
    [SerializeField] private GameObject upIcon;
    [SerializeField] private GameObject downObject;
    [SerializeField] private GameObject downIcon;
    [SerializeField] private TMP_Text resultanttext;
    [SerializeField] private GameObject resultantObj;
    [SerializeField] private UnityEngine.UI.Button moveButton;
    [SerializeField] private ResultantId myresultant;
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private GameObject notificationPanel;

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
    private int resultantInput;
    private int resultantValue;
    private GameObject closeObj1;
    private GameObject closeObj2;
    private GameObject closeIcon1;
    private GameObject closeIcon2;
    private bool resultantCheck = false;

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
                ObjectControl(obj, 0);
                //Debug.Log("0 seçtin");
                break;
            case 1:
                ObjectControl(obj,1);
                //ObjectControl(obj,1);
                //Debug.Log("1 seçtin");
                break;
            case 2:
                ObjectControl(obj,2);
                //ObjectControl(obj, 2);
                //Debug.Log("2 seçtin");
                break;
            case 3:
                ObjectControl(obj,3);
                //ObjectControl(obj,3);
                //Debug.Log("3 seçtin");
                break;
            case 4:
                ObjectControl(obj,4);
                //ObjectControl(obj, 4);
                //Debug.Log("4 seçtin");
                break;
            default:
                //Debug.Log("0 seçtin");
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
            
            upObject.SetActive(false);
            upIcon.SetActive(false);
            downObject.SetActive(false);
            downIcon.SetActive(false);
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
            
            leftObject.SetActive(false);
            leftIcon.SetActive(false);
            rightObject.SetActive(false);
            rightIcon.SetActive(false);
        }
    }

    private void StartAnim()
    {
        if (leftForces > rightForces)
        {
            resultantforcehorizontal = leftForces - rightForces;
        }
        else
        {
            resultantforcehorizontal = rightForces - leftForces;
        }
        //resultantforcehorizontal = leftForces - rightForces;
        Debug.Log(resultantforcehorizontal);
        if (resultantforcehorizontal < 0)
        {
            ResultantValueControl(resultantforcehorizontal, leftObject, rightObject,leftIcon,rightIcon, "Left", true);
            //animTrigger = "Left";
            //animSpeed = -resultantforcehorizontal;
            //Debug.Log("Sola Haraket");
            //resultanttext.text = "Bileþke Kuvvet:" + " " + (-resultantforcehorizontal).ToString() + "N";
            //CloseObjects(leftObject, rightObject);
        }
        else if (resultantforcehorizontal > 0)
        {
            ResultantValueControl(resultantforcehorizontal, leftObject, rightObject,leftIcon,rightIcon, "Right", false);

            //animSpeed = resultantforcehorizontal;
            //resultanttext.text = "Bileþke Kuvvet:" + " " + resultantforcehorizontal.ToString() + "N";
            //Debug.Log("Saða Hareket");
            //animTrigger = "Right";
            //CloseObjects(leftObject, rightObject);

        }
        else
        {
            //resultanttext.text = "Bileþke Kuvvet:" + " " + resultantforcehorizontal.ToString() + "N";
            Debug.Log("Hareketsiz");
        }
        if (upForces > downForces)
        {
            resultantforcevertical = upForces - downForces;
        }
        else
        {
            resultantforcevertical = downForces - upForces;
        }
        //resultantforcevertical = upForces - downForces;
        Debug.Log(resultantforcevertical);
        if (resultantforcevertical < 0)
        {
            ResultantValueControl(resultantforcevertical, upObject, downObject,upIcon,downIcon, "Up", true);

            //Debug.Log("Yukarý Haraket");
            //animTrigger = "Up";
            //animSpeed = -resultantforcevertical;
            //resultanttext.text = "Bileþke Kuvvet:" + " " + (-resultantforcevertical).ToString() + "N";
            //CloseObjects(upObject, downObject);
        }
        else if (resultantforcevertical > 0)
        {
            ResultantValueControl(resultantforcevertical, upObject, downObject,upIcon,downIcon, "Down", false);

            //resultanttext.text = "Bileþke Kuvvet:" + " " + resultantforcevertical.ToString() + "N";
            //Debug.Log("Aþaðý Hareket");
            //animTrigger = "Down";
            //animSpeed = resultantforcevertical;
            //CloseObjects(upObject, downObject);
        }
        else
        {
            //resultanttext.text = "Bileþke Kuvvet:" + " " + resultantforcevertical.ToString() + "N";
            Debug.Log("Hareketsiz");
        }
        if (resultantInput == resultantValue)
        {
            if (closeObj1!=null||closeObj2!=null||closeIcon1!=null||closeIcon2!=null)
            {
                closeObj1.SetActive(false);
                closeObj2.SetActive(false);
                closeIcon1?.SetActive(false);
                closeIcon2?.SetActive(false);
                resultantObj.SetActive(false);
                anim.speed = animSpeed;
                anim.SetTrigger(animTrigger);
            }
            
        }
        else
        {
            SetNotification("Yanlış Değer Girdiniz.");
            //Debug.Log("Yanlış Değer");
        }
        
        
    }

    private int SetForce(int _force,int forces)
    {
        if (id == 0)
        {
            //if (temp0 != 0)
            //{
            //    forces -= temp0;
            //}
            forces += _force;
            temp0 = _force;
        }
        else
        {
            //if (temp1 != 0)
            //{
            //    forces -= temp1;
            //}
            forces += _force;
            temp1 = _force;
        }
        return forces;
    }

    private void CloseObjects(GameObject obj1,GameObject obj2,GameObject icn1,GameObject icn2)
    {
        closeObj1 = obj1;
        closeObj2 = obj2;
        closeIcon1 = icn1;
        closeIcon2 = icn2;
    }

    public void ReadResultantText(string _string)
    {
        if (!resultantCheck)
        {
            SetNotification("Lütfen bileşke kuvveti doğru alana giriniz");
            //Debug.Log("Lütfen bileşke kuvveti doğru alana giriniz");
        }
        else
        {
            if (InputStringControl(_string))
            {
                resultantInput = Int32.Parse(_string);
                Debug.Log("Bileşke kontrol");
            }
            else
            {
                SetNotification("Lütfen Bir Sayı Giriniz");
                //Debug.Log("Lütfen Bir Sayı Giriniz");
            }
        }
        
    }

    private bool InputStringControl(string _s)
    {
        foreach (char item in _s)
        {
            if (!Char.IsNumber(item))
            {
                return false;
            }
        }
        return true;
    }

    private void SetNotification(string _string)
    {
        notificationPanel.SetActive(true);
        notificationText.text= _string;
        StartCoroutine(TimerNotification());
    }

    private IEnumerator TimerNotification()
    {
        yield return new WaitForSeconds(2f);
        notificationPanel.SetActive(false);
    }

    private void ResultantValueControl(int _resultantValue,GameObject obj1,GameObject obj2,GameObject icon1,GameObject icon2,string animString,bool negativeControl)
    {
        animTrigger = animString;
        if (negativeControl)
        {
            animSpeed = -_resultantValue;
            resultantValue = -_resultantValue;
        }
        else
        {
            animSpeed = _resultantValue;
            resultantValue = _resultantValue;
        }
        CloseObjects(obj1, obj2,icon1,icon2);
    }
    public void ResultantIdControl(int _id)
    {
        if (myresultant.Id==_id)
        {
            resultantCheck = true;
        }
        else
        {
            resultantCheck = false;
        }

    }
}
