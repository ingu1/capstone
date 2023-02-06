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

    carscr car;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas").GetComponent<Text>();
        rigid = GameObject.Find("Hypercar2_Simple").GetComponent<Rigidbody>();
        car= GetComponent<carscr>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = rigid.velocity.ToString() + "\n";
        //text.text = "";
        
        /*
        text.text = "질량 : " + rigid.mass.ToString() + " kg";
        text.text += "\n충돌 전 속도 : " + velop + " m/s^2";
        text.text += "\n충돌 후 속도 : " + rigid.velocity.z + " m/s^2";
        text.text += "\n충돌시간 :  " + time + " 초";
        text.text += "\n충격량 : " + impulse + " Ns";
        text.text += "\n힘 : " + force + "N";
        */

    }

    public void Set_velop()
    {
        UnityEngine.Debug.Log("나왔냐?");
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
        force = 12;
    }
    public void Set_car(carscr n_car)
    {
        car = n_car;
    }
    public void Set_rigid(Rigidbody n_rigid)
    {
        rigid = n_rigid;
    }
}
