using NUnit.Framework.Internal.Commands;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pena : MonoBehaviour
{
    private GameObject ply;
    private GameObject penaObj;
    public bool olha = true;
    private Ray ray;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        ply = GameObject.Find("CC");
        penaObj = GameObject.Find("penaEscalada(Clone)");
        transform.LookAt(ply.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20f) == false && olha == true)
        {
            transform.LookAt(ply.transform.position);
            for(float i = 5f; i >= 0f; i -= Time.deltaTime){
                olha = false;
            }
        }

        ply = GameObject.Find("CC");
        
        transform.Translate(0,0, 16 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(penaObj);   
        if(collision.gameObject.name == "Jogador"){
            Debug.Log("Contato");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("gameover");
        }
    }
}
