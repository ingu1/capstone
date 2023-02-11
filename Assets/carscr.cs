using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;


public class carscr : MonoBehaviour
{
    public Stopwatch watch = new Stopwatch();
    float dTime;
    float start;
    float end;
    public Rigidbody rigid = new Rigidbody();
    public GameObject wall;
    public Vector3 startpos;
    public Vector3 startrot;
    Text text;

    //public punchKingscr wall;
    Vector3 vec = new Vector3(0, 0, 1);
    // Start is called before the first frame update

    float velop = 0;
    float time = 0;
    float impulse = 0;
    float force = 0;


    void Start()
    {
        //wall.GetComponent<punchKingscr>().get_time();
        text = GameObject.Find("Canvas").GetComponent<Text>();

        rigid = GetComponent<Rigidbody>();
        float density = 1000;      //밀도
                                   //   rigid.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
                                   //질량



        startpos = transform.position;
        startrot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); 


    }
    private void FixedUpdate()
    {
        dTime += Time.deltaTime;

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigid.velocity += 20 * Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
            rigid.velocity += -20 * Vector3.forward;

        //if (rigid.velocity.z > velop)
        //  velop = rigid.velocity.z;

        //transform.position += -vec * Time.deltaTime * 10;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("Floor"))
            return;

        watch.Reset();

        //        UnityEngine.Debug.Log("충돌전 상대속도 : " + collision.relativeVelocity);


        watch.Start();
        start = dTime;
        //      velop = rigid.velocity.z;
        velop = Vector3.Magnitude(collision.relativeVelocity);  //벡터 크기

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
            return;


        watch.Stop();
        end = dTime;
        //float force = impulse / wall.GetComponent<punchKingscr>().get_time() * 1000;    //힘 근데 왜이리 작게 나와....
        float time = Mathf.Round((end - start) * 100) / 100;
        float impulse = rigid.mass * (velop - rigid.velocity.z);  //충격량(운동량의 변화량)
        float force = impulse / time;    //힘


        /*
         UnityEngine.Debug.Log("질량 : " + rigid.mass + " kg");
         UnityEngine.Debug.Log("충돌 전 속도 : " + velop + " m/s^2");
         UnityEngine.Debug.Log("충돌 후 속도 : " + rigid.velocity.z + " m/s^2");
         UnityEngine.Debug.Log("충돌시간 :  " + time + " 초");
         UnityEngine.Debug.Log("충격량 : " + impulse + " Ns");
         UnityEngine.Debug.Log("힘 : " + force + "N");
        */

        UnityEngine.Debug.Log(transform.rotation);



        text.text = "질량 : " + rigid.mass.ToString() + " kg";
        text.text += "\n충돌 전 속도 : " + velop + " m/s^2";
        text.text += "\n충돌 후 속도 : " + rigid.velocity.z + " m/s^2";
        text.text += "\n충돌시간 :  " + time + " 초";
        text.text += "\n충격량 : " + impulse + " Ns";
        text.text += "\n힘 : " + force + "N";

        /*
        //캔버스 하고싶은... 세팅
        canvas.Set_velop();
        canvas.Set_force(this.force);
        canvas.Set_impulse(this.impulse);
        canvas.Set_time(this.time);
       
        canvas.Set_rigid(this.rigid);
        */
        // float kinetic = 1 / 2 * rigid.mass * (velop - rigid.velocity.z) * (velop - rigid.velocity.z);
        velop = 0;
        //  UnityEngine.Debug.Log("운동에너지 : " + kinetic + " J");        
    }

    public void Reset_car()
    {
        transform.position = startpos;
        transform.rotation = new (0, 0, 0, 0);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        text.text = "";

    }
}