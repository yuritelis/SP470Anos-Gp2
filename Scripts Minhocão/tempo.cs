using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class tempo : MonoBehaviour
{
    private float enemy;

   public Sprite nidere;
   public Sprite nidere_semiapagado;
   public Sprite nidere_apagado;
   public Sprite nidere_chega;
    

    void Start()
    {
       

        enemy = 0;
    }
    // Update is called once per frame
    void Update()
    {
        enemy += Time.deltaTime;

        
            

            if (enemy > 15.0)
            {
                GetComponent<Image>().sprite = nidere_semiapagado;

            }
            if (enemy > 35.0)
            {
                GetComponent<Image>().sprite = nidere_chega;

            }

            if (enemy > 50.0)
            {

                {
                    GetComponent<Image>().sprite = nidere;

                    SceneManager.LoadScene("GameOver");
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }

