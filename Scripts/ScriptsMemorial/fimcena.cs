using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fimcena : MonoBehaviour
{
    public GameObject livro = GameObject.Find("livro");
    public GameObject livro2 = GameObject.Find("livro2");
    public GameObject livro3 = GameObject.Find("livro3");
    public GameObject btv = GameObject.FindGameObjectWithTag("btv");
    public GameObject placa = GameObject.Find("placa");
    private void OnCollisionEnter(Collision collision)
    {
        if (livro == null && livro2 == null && livro3 == null && placa == null && btv == null)
        {
            SceneManager.LoadScene("gameover");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
