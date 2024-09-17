using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class portao : MonoBehaviour
{
    public Transform saida;
    public GameObject passaro;
    harpia script;
    private bool mudartxt = false;
    public TMP_Text _passaroText;
    void Update()
    {
        if (mudartxt)
        {
            _passaroText.text = $"Destrua a Harpia! Atinja a harpia {script.HP.ToString()} vezes!";   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = saida.position;
        script = passaro.GetComponent<harpia>();
        script.enabled = true;
        mudartxt = true;
        
    }
}
