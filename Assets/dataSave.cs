using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;


public class dataSave : MonoBehaviour
{
    string icpPth = "Assets/ICPResult/";
    public InputField InputField;

    // Start is called before the first frame update
    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void create_file()
    {
        int n = 0;
        do
        {
            if (false == File.Exists(icpPth +  "asd_"  + ".txt"))
            {
                var file = File.CreateText(icpPth +  "asd_" + ".txt");
                file.Close();
                break;
            }
            else n++;
        } while (true);
    }

    public void save_data()
    {
        StreamWriter sw = new StreamWriter(icpPth +  "asd_" + ".txt");

        sw.WriteLine("dat");
        sw.WriteLine("dataaa");
        sw.Flush();
        sw.Close();
    }

}
