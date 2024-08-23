using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class trocarcena : MonoBehaviour
{
    public void Voltar()
    {
        SceneManager.LoadScene("memorial");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
