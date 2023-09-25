using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_ene : MonoBehaviour
{
    public float vel = 8;
    public float tiempo = 4;
    Rigidbody2D rb;
    public mov modper;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * vel;
        modper = FindObjectOfType<mov>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            modper.vida--;
        }
    }

}
