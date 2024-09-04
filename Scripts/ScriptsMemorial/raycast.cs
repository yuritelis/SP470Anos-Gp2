using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hitData;
    Vector3 point;
    public Camera _camera;
    public int livrosPegos;
    public TextMeshProUGUI livrosText;
    void Start()
    {

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

            if (tag == "btv")
            {
                Destroy(hitObject);
            }
            if (tag == "livro")
            {
                Destroy(hitObject);
                livrosPegos++;
            }
            if (tag == "livro2")
            {
                Destroy(hitObject);
                livrosPegos++;
            }
            if (tag == "livro3")
            {
                Destroy(hitObject);
                livrosPegos++;
            }
            if (tag == "livro4")
            {
                Destroy(hitObject);
                livrosPegos++;
            }
            livrosText.text = "- Pegar " + livrosPegos.ToString() + "/3 livros";
        }
        else
        {
            Debug.Log("Target missed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Lancar(ray);
        }
    }
}
