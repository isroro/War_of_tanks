using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mov : MonoBehaviour
{
    public InputAction movi;
    //public InputAction recargar;
    public InputAction dash;

    public GameObject cuerpotanque;
    Rigidbody2D rb;
    public Animator anim;

    public float tiempo = 0;
    public float vel = 3;
    public int vida = 10;
    public int acel = 3;
    // Start is called before the first frame update
    void Start()
    {
        movi.Enable();
        dash.Enable();
        //recargar.Enable();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movactu;
        movactu = movi.ReadValue<Vector2>();
        rb.velocity = movactu * vel;
        if (dash.triggered)
        {
            tiempo = 0.5f; 
        }
        if (tiempo > 0)
        {
            rb.velocity = rb.velocity * acel;
            tiempo -= Time.deltaTime;
        }
        if (vida >= 10)
        {
            vida = 10;
        }
    }
}
