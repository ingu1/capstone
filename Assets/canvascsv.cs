using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class canvascsv : MonoBehaviour
{
    Text text;
    float mass;
    float time;
    float impulse;
    float force;

    Rigidbody rigid;
    float velop = 0;



    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas").GetComponent<Text>();
        rigid = GameObject.Find("Hypercar2_Simple").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //text.text = rigid.velocity.ToString() + "\n";
        //text.text = "";
        text.text = "���� : " + rigid.mass.ToString() + " kg";
        text.text += "\n�浹 �� �ӵ� : " + velop + " m/s^2";
        text.text += "\n�浹 �� �ӵ� : " + rigid.velocity.z + " m/s^2";
        text.text += "\n�浹�ð� :  " + time + " ��";
        text.text += "\n��ݷ� : " + impulse + " Ns";
        text.text += "\n�� : " + force + "N";
    }

    public void Set_velop()
    {
        UnityEngine.Debug.Log("���Գ�?");
       
    }

    public void Set_time(float ti)
    {
        time = ti;
    }

    public void Set_impulse(float imp)
    {
        impulse = imp;
    }

    public void Set_force(float fo)
    {
        force = fo;
    }

}
