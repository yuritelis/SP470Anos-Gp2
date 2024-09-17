using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class jogador : MonoBehaviour
{
    public Camera _camera;
    public GameObject pedra;
    public Transform mao;
    int pedras;
    public RaycastHit hitData;
    public TMP_Text _pedras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hitData)){
            _pedras.text = pedras.ToString();
            if (hitData.collider.tag == "pedra" && pedras < 3 && Input.GetKeyDown(KeyCode.Mouse1))
            {
                pedras++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && pedras > 0){
            Instantiate(pedra, new Vector3(mao.position.x, mao.position.y, mao.position.z), _camera.transform.rotation);
            pedras--;
        }
    }
}
