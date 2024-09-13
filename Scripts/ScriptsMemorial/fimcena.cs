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
    public GameObject lobos;

    private void OnCollisionEnter(Collision collision)
    {
        if (livro == null && livro2 == null && livro3 == null && btv == null && lobos == null)
        {
            SceneManager.LoadScene("augusta");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("mudou cena");
        }
    }
    void Start()
    {
        livro = GameObject.Find("livro");
        livro2 = GameObject.Find("livro 2");
        livro3 = GameObject.Find("livro 3");
        btv = GameObject.Find("bemtevi2 (1)");
        lobos = GameObject.Find("lobos guara");
    }
}
