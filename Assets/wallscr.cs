using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallscr : MonoBehaviour
{


    //  if (collision.collider.gameObject.CompareTag("Floor"))

    public Rigidbody rigid = new Rigidbody();
    public Transform transform;

    int mode = 0;

    // Start is called before the first frame update
    void Start()
    {

        transform = GameObject.Find("Wall").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_mode()
    {
        if (mode == 0)
        {
            transform.position = new(0, 0, 10);
            transform.localScale = new(80, 40, 3);
            mode++;

        }
        else
        {
            transform.position = new((float)2.6, 5, 10);
            transform.localScale = new(5, 5, 3);
            mode--;
        }

    }



}
