using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Analytics.IAnalytic;

public class Placa : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    bool m_Tocando;
    public GameObject placa;
    public GameObject lobo;
    public bool persegue;
    public float tempo;
    public bool tempoLigado;
    public TextMeshProUGUI tempoText;
    Ray ray;
    RaycastHit hitData;
    Vector3 point;

    private void Contagem()
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

    void Som()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();
    }

    private void Lancar(Ray ray)
    {
        Debug.Log("Origem: " + ray.origin);
        Debug.Log("Direção: " + ray.direction);

        if (Physics.Raycast(ray, out hitData))
        {
            Vector3 hitPosition = hitData.point;
            Debug.Log(" hitPosition:" + hitPosition);


            float hitDistance = hitData.distance;
            Debug.Log("Distancia: " + hitDistance);
            string tag = hitData.collider.tag;
            Debug.Log("Tag:" + tag);
            GameObject hitObject = hitData.transform.gameObject;

            if (tag == "placa")
            {
                tempoLigado = true;
                m_Tocando = true;
                if (m_Tocando == true)
                {
                    Som();
                }
                persegue = true;
                if (persegue == true)
                {
                    Destroy(lobo);
                }
            }
        }
    }

    void Start()
    {
        lobo = GameObject.Find("lobos guara");
        
        m_Tocando = false;
        tempoLigado = false;
        persegue = false;
        tempo = 25;
    }

    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Lancar(ray);
        }
        if (tempoLigado == true)
        {
            Contagem();
        }
    }
}