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

        //UnityEngine.Debug.Log("�浹�� ���ӵ� : " + collision.relativeVelocity);
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
        //UnityEngine.Debug.Log("�浹�� ���ӵ� : " + collision.relativeVelocity);
        //UnityEngine.Debug.Log("�浹�ð� : " + watch.ElapsedMilliseconds + " ms");

        //UnityEngine.Debug.Log(Time.deltaTime + "  ��Ÿ��Ÿ��Ÿ");

        //UnityEngine.Debug.Log("�浹�ð� : " + (end - start) + " ��Ÿ��Ÿ ms");
        //UnityEngine.Debug.Log(start + " ���۵�Ÿ ms");
        //UnityEngine.Debug.Log(end + " ������Ÿ ms");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
