using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoSingleton<ProjectManager>
{
    private int FinishCount;
    [SerializeField] private GameObject finishPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountIncreasing()
    {
        FinishCount++;
        if (FinishCount >= 3)
        {
            StartCoroutine(FinishPanelTimer());
        }
    }

    private IEnumerator FinishPanelTimer()
    {
        yield return new WaitForSeconds(2);
        finishPanel.SetActive(true);
    }
}
