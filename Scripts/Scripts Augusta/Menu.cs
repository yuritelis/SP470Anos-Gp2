using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trocarcena : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene("augusta");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
        Cursor.lockState = CursorLockMode.None;
    }
    public void Sair()
    {
        Application.Quit();
    }
}