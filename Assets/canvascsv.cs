using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvascsv : MonoBehaviour
{
    Text text;
    float mass;

    int i = 9;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas").GetComponent<Text>();
        rigid = GameObject.Find("Hypercar2_Simple").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = rigid.velocity.ToString();


    }
}
