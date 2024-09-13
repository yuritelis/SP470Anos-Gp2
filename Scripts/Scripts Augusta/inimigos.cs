using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Inimigos : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hitData;
    Vector3 point;
    float Dano;
    public Camera _camera;
    float MaxDistance = 2;

    public Text Lobos;
    public Text Salvos;
    public int mordidos;
    public int liberto;

    Rigidbody rbJaula;
    public float m_thrust = 20f;

    public AudioSource sound;
    void Start()
    {
        Debug.Log("inicio");
       

       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            Lancar(ray, 1);
        }


    }
    public void Lancar(Ray ray, int tipo)
    {



        if (Physics.Raycast(ray, out hitData, MaxDistance))
        {
            Vector3 hitPosition = hitData.point;


            float hitDistance = hitData.distance;

            string tag = hitData.collider.tag;

            GameObject hitObject = hitData.transform.gameObject;
            Debug.DrawRay(ray.origin, hitPosition * hitDistance);

           

            if (tag == "target")
            {
                
                Destroy(hitObject);
                mordidos++;
                Lobos.text = mordidos.ToString();
               



            }

            else if (tag == "jaulas")
            {
                Audi();
                rbJaula = hitData.collider.GetComponent<Rigidbody>();
                rbJaula.AddForce(transform.forward * m_thrust);
                
                liberto++;      
                Salvos.text = liberto.ToString();
                hitData.collider.tag = "JaulaAb";
                
                rbJaula = null;
              
            }
            else if (tag == "pedra")
            {
                Rigidbody pedra = hitData.collider.GetComponent<Rigidbody>();
                pedra.AddForce(-transform.forward * m_thrust * 100f);
                hitData.collider.tag = "Untagged";

            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * 1000);
                Debug.Log("Target missed");

            }


           if(liberto == 24 && mordidos == 36)
            {
                SceneManager.LoadScene("menu");
            }
        }
      


        }
    public void Audi()
    {
        sound = hitData.collider.GetComponent<AudioSource>();
        sound.Play();
    }
   


}