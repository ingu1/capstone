using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;


public class dataSave : MonoBehaviour
{
   
    public Slider sli;
    void Start()
    {


        sli = GameObject.Find("Slider").GetComponent<Slider>();

        
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}


 //           UnityEngine.Debug.Log("sad");
