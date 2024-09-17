using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class harpia : MonoBehaviour
{
    public GameObject passaro;
    public GameObject pena;
    private GameObject penaCena;
    GameObject rota;
    Vector3 rotaPos;
    Vector3 pyPos;
    int passos = 1;
    int passoAtual;
    private bool podeMover;
    float cooldown = 5f;
    public int HP = 3;
    void Awake() {
        podeMover = false;
        transform.LookAt(pyPos);
    }

    void FixedUpdate() {
        rota = GameObject.Find($"trajeto({passos})");
        rotaPos = rota.transform.position;
        pyPos = GameObject.Find("CC").transform.position;
    }
    void Update()
    {
        passoAtual = passos - 1;
        if(!podeMover)
        {
            transform.LookAt(pyPos);
        }else
        {
           transform.LookAt(rotaPos);
        }

        if(HP == 2){
            podeMover = true;
            if (passoAtual == 3){
                podeMover = false;
                transform.position = GameObject.Find($"trajeto({passoAtual})").transform.position;
            }
        }
        if(HP == 1)
        {
            podeMover = true;
            if (passos == 8){
                podeMover = false;
                transform.position = GameObject.Find($"trajeto({passos})").transform.position;
            }
        }
        if (HP == 0) 
        {
            Cursor.lockState = CursorLockMode.None;
            Destroy( passaro );
            SceneManager.LoadScene("menu");
        }
        movimento(podeMover);
        
        //lançar penas
        if(!podeMover)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0){
                Instantiate(pena, new Vector3(transform.position.x, transform.position.y, transform.position.z + 3f), transform.rotation);
                cooldown = 5f;
            }
        }
        
    }
    private void movimento(bool liber)
    {
        if(liber)
        {
            transform.Translate(new Vector3(0,0, Time.deltaTime * 10));
        }
    }
    void OnTriggerEnter(Collider other) {
        if (passos < 8)
        {
            Debug.Log($"Atingiu alvo {passos}");
            passos++;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pedra")
        {
            HP--;
            rota = GameObject.Find($"trajeto({passos})");
        }
    }
}
