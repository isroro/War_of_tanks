using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public mov jugador;
    public arbitro arbi;

    public float tiempodisparo = 10;
    public float tiempomov = 0;
    public float vel = 1.5f;
    public int probabilidad;

    public GameObject modbala;
    public GameObject botiquin;
    public GameObject bomba;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        arbi = FindObjectOfType<arbitro>();
        jugador = FindObjectOfType<mov>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        arbi.enemigos += 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccion = jugador.transform.position - gameObject.transform.position;
        direccion = direccion.normalized;

        if (tiempomov <= 0)
        {
            rb.velocity = direccion * vel;
        }
        if (tiempomov >= 0)
        {
            tiempomov -= Time.deltaTime;
            rb.velocity = direccion * 0;
        }
        

        var dir = jugador.gameObject.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90 , Vector3.forward);

        tiempodisparo -= Time.deltaTime;

        if (tiempodisparo <= 0)
        {
            GameObject newbala = Instantiate(modbala);
            newbala.transform.position = gameObject.transform.position;
            newbala.transform.up = new Vector3(jugador.gameObject.transform.position.x - transform.position.x, jugador.gameObject.transform.position.y - transform.position.y);
            tiempodisparo = 5;
            tiempomov = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            Muerete();
        }
    }
    public void Muerete()
    {
        arbi.enemigos -= 1;
        if (Random.Range(0, 101) <= probabilidad)
        {
            if (Random.Range(1, 3) == 2)
            {
                Instantiate(botiquin, gameObject.transform.position, Quaternion.identity);
                Debug.Log("boti");
            }
            else
            {
                Instantiate(bomba, gameObject.transform.position, Quaternion.identity);
                Debug.Log("bomba");
            }
        }
        gameObject.SetActive(false);
    }
}
