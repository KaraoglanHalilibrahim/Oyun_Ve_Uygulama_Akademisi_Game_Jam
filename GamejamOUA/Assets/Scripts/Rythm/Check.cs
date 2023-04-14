using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    public bool canPressed;
    public KeyCode keyToPress;
    public GameObject progressBar;
    public int totalArrows;
    public int arrowsHit;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Activator")
        {
            canPressed = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Activator")
        {
            canPressed = false;
        }    
    }

    void Start()
    {
        totalArrows = 10;
        arrowsHit = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canPressed)
            {
                gameObject.SetActive(false);
                arrowsHit++;
                UpdateProgressBar();
            }
        }
    }

    void UpdateProgressBar()
    {
        float progress = (float)arrowsHit / totalArrows;
        progressBar.GetComponent<RectTransform>().localScale = new Vector3(progress, 1f, 1f);
        progressBar.GetComponent<Image>().fillAmount = progress;
        progressBar.GetComponent<Image>().color = Color.green;
    }
    
}
