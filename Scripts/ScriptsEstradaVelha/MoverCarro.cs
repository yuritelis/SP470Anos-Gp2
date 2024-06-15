using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    public Rigidbody rb;
    public Transform passaro;         // Referência ao GameObject do pássaro
    public float speed = 5.0f;        // Velocidade do carro
    public float stopDistance = 10.0f;
    float vel = 0f;
    float rotX = 0f;
    float sensibilidade = 1f;
    Vector3 pulo = new Vector3(0, 3f, 0);
    public GameObject botao;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimentação
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vel = 14.6f;
        }
        else
        {
            vel = 8.5f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(vel * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(vel * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, vel * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -(vel * Time.deltaTime));
        }

        // Rotação
        rotX += Input.GetAxis("Mouse X") * sensibilidade;
        transform.eulerAngles = new Vector3(0, rotX, 0);

        // Raycast para pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1.5f))
            {
                rb.AddForce(pulo * 2.0f, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("no ar");
            }
        }

        // Movimento em direção ao pássaro
        if (passaro != null)
        {
            Vector3 direction = passaro.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            float distance = Vector3.Distance(transform.position, passaro.position);
            if (distance > stopDistance)
            {
                SceneManager.LoadScene("Perdeu");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Se entrar em colisão com o chão "chaomorreu"
        if (other.gameObject.CompareTag("chaomorreu"))
        {
            SceneManager.LoadScene("Perdeu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se colidir fisicamente com o cubo onde o pássaro joga os ovos
        if (collision.gameObject.CompareTag("cuboPassaro"))
        {
            SceneManager.LoadScene("Perdeu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (collision.gameObject.CompareTag("chegada"))
        {
            SceneManager.LoadScene("Venceu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider outro)
    {
        if (outro.gameObject.tag == "passaro")
        {
            Debug.Log("saiuy da area do passaro");
            SceneManager.LoadScene("Perdeu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}


