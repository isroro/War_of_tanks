using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    enemigo[] listaenemigos;
    public float alcance;
    public bool autodestruccion = false;
    public float tiempo = 0.001f;
    public GameObject estructura;
    public GameObject explosión;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (autodestruccion == true)
        {
            tiempo -= Time.deltaTime;
        }
        if (tiempo <= 0)
        {
            gameObject.SetActive(false);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // buscar enemigos en pantalla
            listaenemigos = FindObjectsOfType<enemigo>();
            // recorrer la lista
                estructura.SetActive(false);
                explosión.SetActive(true);
            for (int contador = 0; contador < listaenemigos.Length; contador++)
            {
                
                //trabajar con el enemigo indice de la lista
                enemigo esteenemigo = listaenemigos[contador];
                //si esta cerca de la bomba
                if (Vector2.Distance(esteenemigo.transform.position, gameObject.transform.position) < alcance)
                {
                    //matarlo
                    esteenemigo.Muerete();
                }
                // bomba goes boom
                //autodestruccion = true;
                Destroy(gameObject, 0.3f);
            }

        }
    }
}
