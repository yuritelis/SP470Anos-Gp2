using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class iluminacao : MonoBehaviour
{



    //public GameObject ilumi;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ilumi += Time.deltaTime;
        transform.RotateAround(transform.position, Vector3.up, 2 * Time.deltaTime);



    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Debug.Log("destroi");
                Destroy(gameObject);
                break;
        }
    }
}
