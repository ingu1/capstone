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

        float density = 10;      //�е�
        rigid.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
        //����

        //density �Ҽ��� �ϸ� �ݿø� �ؾ� ������...



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

        //        UnityEngine.Debug.Log("�浹�� ���ӵ� : " + collision.relativeVelocity);


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
        //float force = impulse / wall.GetComponent<punchKingscr>().get_time() * 1000;    //�� �ٵ� ���̸� �۰� ����....
        float time = Mathf.Round((end - start) * 100) / 100;
        float impulse = rigid.mass * (velop - rigid.velocity.z);  //��ݷ�(����� ��ȭ��)
        float force = impulse / time;    //��

        UnityEngine.Debug.Log("���� : " + rigid.mass + " kg");
        UnityEngine.Debug.Log("�浹 �� �ӵ� : " + velop + " m/s^2");
        UnityEngine.Debug.Log("�浹 �� �ӵ� : " + rigid.velocity.z + " m/s^2");
        UnityEngine.Debug.Log("�浹�ð� :  " + time + " ��");
        UnityEngine.Debug.Log("��ݷ� : " + impulse + " Ns");
        UnityEngine.Debug.Log("�� : " + force + "N");

        // float kinetic = 1 / 2 * rigid.mass * (velop - rigid.velocity.z) * (velop - rigid.velocity.z);
        velop = 0;
        //  UnityEngine.Debug.Log("������� : " + kinetic + " J");        
    }
}