using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class perseguicao : MonoBehaviour
{
    public GameObject placa;
    public GameObject lobo;
    public float tempo;
    public bool tempoLigado;
    public TextMeshProUGUI tempoText;

    void Start()
    {
        tempoLigado = false;
        tempo = 20;
    }

    void Update()
    {
        lobo = GameObject.FindGameObjectWithTag("inimigo");
        placa = GameObject.Find("placa");

        if (placa == null)
        {
            tempoLigado = true;
            if (tag == "inimigo")
            {
                Destroy(lobo);
            }
            if (tempoLigado)
            {
                tempo -= Time.deltaTime;
                tempoText.text = tempo.ToString("F2");
                if (tempo < 0)
                {
                    SceneManager.LoadScene("gameover");
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
}
