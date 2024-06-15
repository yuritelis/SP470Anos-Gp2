using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Funcoes : MonoBehaviour
{
    private void Start()
    {
        // Obtém o Collider do objeto ao qual este script está anexado
        Collider collider = GetComponent<Collider>();

        // Verifica se o Collider é um Box Collider e desativa o Trigger se necessário
        if (collider is BoxCollider)
        {
            BoxCollider boxCollider = (BoxCollider)collider;
            boxCollider.isTrigger = false; // Garante que não seja um Trigger se não for desejado
        }
    }

    // Start is called before the first frame update
    public void Voltar()
    {
        SceneManager.LoadScene("EstradaVelha");
    }
    


    
}
