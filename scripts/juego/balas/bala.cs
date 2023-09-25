using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float vel = 8;
    public float tiempo = 4;

    Rigidbody2D rb;

    public arbitro arbi;
    public enemigo enemigos;

    public mov modper; //quitar vidas
    // Start is called before the first frame update
    void Start()
    {
        enemigos = FindObjectOfType<enemigo>();
        modper = FindObjectOfType<mov>();
        arbi = FindObjectOfType<arbitro>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * vel;
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        if(tiempo <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            //collision.gameObject.SetActive(false);
            //arbi.enemigos -=  1;
            gameObject.SetActive(false);
        }
    }
}
