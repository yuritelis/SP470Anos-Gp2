using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buracos : MonoBehaviour
{
    private int collidedTimes = 0;

    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {

            case "hole":
                SceneManager.LoadScene("GameOver");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;

            case "fim":

                Application.Quit();

                break;





        }

    }
}
