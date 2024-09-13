using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Collission : MonoBehaviour
{

    public AudioSource audi;

    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            SceneManager.LoadScene("gameover" );
            Cursor.lockState = CursorLockMode.None;
             
        }
           

    }
}
