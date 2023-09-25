using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botiquín : MonoBehaviour
{
    public mov contadorvida;
    // Start is called before the first frame update
    void Start()
    {
        contadorvida = FindObjectOfType<mov>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            contadorvida.vida += 2;
            gameObject.SetActive(false);
        }
    }
}
