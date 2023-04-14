using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public List<RectTransform> arrowImages; 

    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
    
        foreach (RectTransform arrowImage in arrowImages)
        {
            if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(arrowImage, Input.mousePosition))
            {
                arrowImage.gameObject.SetActive(false);
            }
            arrowImage.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime * 100f);
        }
    }
}
