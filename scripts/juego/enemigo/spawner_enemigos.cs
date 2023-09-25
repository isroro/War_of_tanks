using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_enemigos : MonoBehaviour
{
    public int cantidadEnemigos = 0;
    public float tiempo = 2.5f;
    public float tiempoini = 3;
    public bool activo;

    public GameObject enemigo;

    public arbitro arbi;

    // Start is called before the first frame update
    void Start()
    {
        arbi = FindObjectOfType<arbitro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arbi.ronda != cantidadEnemigos && arbi.enemigos == 0)
        {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                cantidadEnemigos = arbi.ronda -1;
                tiempo = tiempoini;
            }
        }
        while (cantidadEnemigos > 0)
        {
            Instantiate(enemigo, gameObject.transform.position, Quaternion.identity);
            cantidadEnemigos -= 1;
        }
    }
}
