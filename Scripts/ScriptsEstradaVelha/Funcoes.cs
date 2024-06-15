using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Funcoes : MonoBehaviour
{
    private void Start()
    {
        // Obt�m o Collider do objeto ao qual este script est� anexado
        Collider collider = GetComponent<Collider>();

        // Verifica se o Collider � um Box Collider e desativa o Trigger se necess�rio
        if (collider is BoxCollider)
        {
            BoxCollider boxCollider = (BoxCollider)collider;
            boxCollider.isTrigger = false; // Garante que n�o seja um Trigger se n�o for desejado
        }
    }

    // Start is called before the first frame update
    public void Voltar()
    {
        SceneManager.LoadScene("EstradaVelha");
    }
    


    
}
