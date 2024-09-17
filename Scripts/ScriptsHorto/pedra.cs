using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedra : MonoBehaviour
{
    private float tempoVida = 15f;
    public Rigidbody rb;
    public GameObject eu;
    private bool lancar;
    void Start()
    {
        tempoVida = 15f;
        lancar = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tempoVida -= Time.deltaTime;
        if (lancar)
        {
            rb.AddForce((transform.forward * 300f) + (transform.up * 75f), ForceMode.Impulse);
            lancar = false;
        }
        if (tempoVida < 0) { 
            Destroy(eu);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(eu);
    }
}
