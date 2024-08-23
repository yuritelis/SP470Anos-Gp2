using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    /*public float pulo = 3.0f;
    public float massa = 3.0f;
    private Rigidbody rb;
    private bool chao = false;*/
    void Start()
    {
        /*rb = GetComponent<Rigidbody>();
        rb.mass = massa;*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, 0.7f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -0.7f);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(0.3f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.3f, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, 1.0f);
        }

        /*if (!Input.GetKeyDown(KeyCode.Space) || !chao)
            return;
        rb.AddForce(
            Vector3.up * pulo,
            ForceMode.Impulse);*/
    }
    /*void OnCollisionEnter(Collision collision)
    {
        chao = true;
    }
    void OnCollisionExit(Collision collision)
    {
        chao = false;
    }*/

}
