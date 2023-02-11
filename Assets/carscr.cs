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
        float density = 1000;      //�е�
                                   //   rigid.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
                                   //����



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

        //        UnityEngine.Debug.Log("�浹�� ���ӵ� : " + collision.relativeVelocity);


        watch.Start();
        start = dTime;
        //      velop = rigid.velocity.z;
        velop = Vector3.Magnitude(collision.relativeVelocity);  //���� ũ��

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


        /*
         UnityEngine.Debug.Log("���� : " + rigid.mass + " kg");
         UnityEngine.Debug.Log("�浹 �� �ӵ� : " + velop + " m/s^2");
         UnityEngine.Debug.Log("�浹 �� �ӵ� : " + rigid.velocity.z + " m/s^2");
         UnityEngine.Debug.Log("�浹�ð� :  " + time + " ��");
         UnityEngine.Debug.Log("��ݷ� : " + impulse + " Ns");
         UnityEngine.Debug.Log("�� : " + force + "N");
        */

        UnityEngine.Debug.Log(transform.rotation);



        text.text = "���� : " + rigid.mass.ToString() + " kg";
        text.text += "\n�浹 �� �ӵ� : " + velop + " m/s^2";
        text.text += "\n�浹 �� �ӵ� : " + rigid.velocity.z + " m/s^2";
        text.text += "\n�浹�ð� :  " + time + " ��";
        text.text += "\n��ݷ� : " + impulse + " Ns";
        text.text += "\n�� : " + force + "N";

        /*
        //ĵ���� �ϰ����... ����
        canvas.Set_velop();
        canvas.Set_force(this.force);
        canvas.Set_impulse(this.impulse);
        canvas.Set_time(this.time);
       
        canvas.Set_rigid(this.rigid);
        */
        // float kinetic = 1 / 2 * rigid.mass * (velop - rigid.velocity.z) * (velop - rigid.velocity.z);
        velop = 0;
        //  UnityEngine.Debug.Log("������� : " + kinetic + " J");        
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