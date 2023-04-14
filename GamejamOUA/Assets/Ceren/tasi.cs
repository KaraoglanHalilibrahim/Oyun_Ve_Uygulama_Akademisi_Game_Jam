using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tasi : MonoBehaviour
{
    // Start is called before the first frame update

    Camera kamera;
    Vector2 baslangic_pozisyonu;


    GameObject[] kututag_dizisi;
    yonetici yonet;


    private void OnMouseDrag()
    {


        Vector3 pozisyon = kamera.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
    }
    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        baslangic_pozisyonu = transform.position;

        kututag_dizisi = GameObject.FindGameObjectsWithTag("kututag");
       yonet = GameObject.Find("yonetici").GetComponent<yonetici>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {

            foreach (GameObject kututag in kututag_dizisi)
            {


                if (kututag.name  == gameObject.name)
                {
                    float mesafe = Vector3.Distance(kututag.transform.position, transform.position);
                    {

                        if (mesafe <= 1)
                        {
                            transform.position = kututag.transform.position;
                            yonet.sayi_arttir();
                            this.enabled = false;
                        }
                        else
                        {
                            transform.position = baslangic_pozisyonu;
                        }







                    }
                }

            }

        }
    }
}











