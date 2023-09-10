using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] private GameObject SecondObject;
    [SerializeField] private GameObject DeneyObject;
    [SerializeField] private GameObject QuestionObject;
    public float SecondActiveTime;
    public float QuestionActiveTime;
    void Start()
    {
        StartCoroutine(SecondActiveObject());
        StartCoroutine(QuestionActive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SecondActiveObject()
    {
        yield return new WaitForSeconds(SecondActiveTime);
        SecondObject.SetActive(true);
    }

    private IEnumerator QuestionActive()
    {
        yield return new WaitForSeconds(QuestionActiveTime);
        DeneyObject.SetActive(false);
        QuestionObject.SetActive(true);
    }

    private IEnumerator CloseNotObjTime(GameObject Obj)
    {
        yield return new WaitForSeconds(0.5f);
        Obj.SetActive(false);

    }

    public void CloseNotObj(GameObject Obj)
    {
        StartCoroutine(CloseNotObjTime(Obj));
    }
    public void OpenNotObj(GameObject Obj)
    {
        Obj.SetActive(true);
    }


}
