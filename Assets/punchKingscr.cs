using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class punchKingscr : MonoBehaviour
{
    // Start is called before the first frame update
    public Stopwatch watch = new Stopwatch();
    float dTime;
    float start;
    float end;
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        dTime += Time.deltaTime;

    }


    public float get_time()
    {
        return end - start;
    }
    private void OnCollisionEnter(Collision collision)
    {
        watch.Reset();

        //UnityEngine.Debug.Log("충돌전 상대속도 : " + collision.relativeVelocity);
        watch.Start();
        start = dTime;
    }

    private void OnCollisionStay(Collision collision)
    {
       
    }

    private void OnCollisionExit(Collision collision)
    {
        watch.Stop();
        end = dTime;
        //UnityEngine.Debug.Log("충돌후 상대속도 : " + collision.relativeVelocity);
        //UnityEngine.Debug.Log("충돌시간 : " + watch.ElapsedMilliseconds + " ms");

        //UnityEngine.Debug.Log(Time.deltaTime + "  델타델타델타");

        //UnityEngine.Debug.Log("충돌시간 : " + (end - start) + " 델타델타 ms");
        //UnityEngine.Debug.Log(start + " 시작델타 ms");
        //UnityEngine.Debug.Log(end + " 끝끝델타 ms");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
