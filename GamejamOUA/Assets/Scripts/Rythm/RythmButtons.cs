using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmButtons : MonoBehaviour
{
    private Image image;
    public Sprite defaultImg;
    public Sprite pressedImg;
    public KeyCode keyToPress;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            image.sprite = pressedImg;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            image.sprite = defaultImg;
        }
    }
}
