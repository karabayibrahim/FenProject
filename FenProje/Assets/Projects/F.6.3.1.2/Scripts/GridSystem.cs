using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridSystem : MonoBehaviour
{
    [SerializeField] private float negativeXvalue;
    [SerializeField] private float positiveXvalue;
    [SerializeField] private float negativeYvalue;
    [SerializeField] private float positiveYvalue;
    [SerializeField] private Image gridImage;
    [SerializeField] private Canvas canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnValidate()
    //{
    //    CreateGrids();
    //}
#if UNITY_EDITOR
    private void CreateGrids()
    {
        for (int i = 0; i >= negativeXvalue; i-=100)
        {
            for (int t = 0; t >= negativeYvalue; t-=100)
            {
                var newGridImage=Instantiate(gridImage);
                newGridImage.transform.SetParent(canvas.transform);
                newGridImage.rectTransform.anchoredPosition = new Vector3(i, t);
            }
            for (int z = 100; z <= positiveYvalue; z += 100)
            {
                var newGridImage = Instantiate(gridImage);
                newGridImage.transform.SetParent(canvas.transform);
                newGridImage.rectTransform.anchoredPosition = new Vector3(i, z);
            }
            
        }
        for (int i = 100; i <= positiveXvalue; i += 100)
        {
            for (int t = 0; t <= positiveYvalue; t += 100)
            {
                var newGridImage = Instantiate(gridImage);
                newGridImage.transform.SetParent(canvas.transform);
                newGridImage.rectTransform.anchoredPosition = new Vector3(i, t);
            }
            for (int t = -100; t >= negativeYvalue; t -= 100)
            {
                var newGridImage = Instantiate(gridImage);
                newGridImage.transform.SetParent(canvas.transform);
                newGridImage.rectTransform.anchoredPosition = new Vector3(i, t);
            }

        }
    }
#endif
}
