using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelManager : MonoBehaviour
{
    [SerializeField] private RawImage myImage;
    [SerializeField] private Texture openTexture;
    [SerializeField] private Animator animator;
    //[SerializeField] private Animator firstActiveAnimator;
    [SerializeField] private List<Animator> animations;

    public float FirstActimeTime;
    void Start()
    {
        StartCoroutine(FirstActive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenLamb()
    {
        myImage.texture = openTexture;
        animator.enabled = true;
    }

    public void AnimExit()
    {
        //StartCoroutine(AnimTime(animator,iskey));
    }

    private IEnumerator AnimTime()
    {
        foreach (var item in animations)
        {
            item.enabled = true;
            yield return new WaitForSeconds(2f);
            if (item.CompareTag("Key"))
            {
                OpenLamb();
            }
        }
        //if (iskey)
        //{
        //    OpenLamb();
        //}
        //animator.enabled = true;

    }

    private IEnumerator FirstActive()
    {
        yield return new WaitForSeconds(FirstActimeTime);
        StartCoroutine(AnimTime());
        //firstActiveAnimator.enabled = true;
    }
}
