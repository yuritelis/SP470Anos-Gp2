using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trocarF : MonoBehaviour
{ 
 public void Volt()
{
    SceneManager.LoadScene("Minhoc�o");
}
public void sair()
{
    Application.Quit();
}
public void menu()
{
    SceneManager.LoadScene("menu");
}
}