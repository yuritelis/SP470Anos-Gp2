using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fimcena : MonoBehaviour
{
    public GameObject livro;
    public GameObject livro2;
    public GameObject livro3;
    public GameObject btv;
    public GameObject placa;
    private void OnCollisionEnter(Collision collision)
    {
        if (livro == null && livro2 == null && livro3 == null && placa == null && btv == null)
        {
            SceneManager.LoadScene("augusta");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void Start()
    {
        livro = GameObject.Find("livro");
        livro2 = GameObject.Find("livro2");
        livro3 = GameObject.Find("livro3");
        btv = GameObject.FindGameObjectWithTag("btv");
        placa = GameObject.Find("placa");
    }
}
