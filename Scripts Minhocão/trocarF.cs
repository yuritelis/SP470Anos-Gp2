using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trocarF : MonoBehaviour
{ 
 public void Volt()
{
    SceneManager.LoadScene("Minhocão");
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