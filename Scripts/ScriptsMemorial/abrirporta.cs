using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirporta : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject livro;
    public GameObject livro2;
    public GameObject livro3;
    public GameObject placa;
    public bool pegouLivro = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livro = GameObject.Find("livro");
        livro2 = GameObject.Find("livro 2");
        livro3 = GameObject.Find("livro 3");
        placa = GameObject.Find("placa");

        if (livro == null && livro2 == null && livro3 == null && placa == null)
        {
            rb.AddForce(transform.forward * -15f);
        }
    }
}
