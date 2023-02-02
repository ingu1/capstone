using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class hitBallscr : MonoBehaviour
{
    public Stopwatch watch = new Stopwatch();
    float dTime;
    float start;
    float end;
    Rigidbody rigid;
    public GameObject wall;

    //public punchKingscr wall;
    Vector3 vec = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    float velop = 0;
    void Start()
    {
        wall.GetComponent<punchKingscr>().get_time();

        rigid = GetComponent<Rigidbody>();

        float density = 10;      //밀도
        rigid.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
        //질량

        //density 소수로 하면 반올림 해야 될지도...



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
            rigid.velocity += 6 * Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
            rigid.velocity += -6 * Vector3.forward;
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
        velop = Vector3.Magnitude(collision.relativeVelocity);


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

        UnityEngine.Debug.Log("질량 : " + rigid.mass + " kg");
        UnityEngine.Debug.Log("충돌 전 속도 : " + velop + " m/s^2");
        UnityEngine.Debug.Log("충돌 후 속도 : " + rigid.velocity.z + " m/s^2");
        UnityEngine.Debug.Log("충돌시간 :  " + time + " 초");
        UnityEngine.Debug.Log("충격량 : " + impulse + " Ns");
        UnityEngine.Debug.Log("힘 : " + force + "N");

        // float kinetic = 1 / 2 * rigid.mass * (velop - rigid.velocity.z) * (velop - rigid.velocity.z);
        velop = 0;
        //  UnityEngine.Debug.Log("운동에너지 : " + kinetic + " J");        
    }
}