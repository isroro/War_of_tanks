using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class personaje : MonoBehaviour
{
    public GameObject modbala;
    public InputAction disparar;
    public InputAction recargar;

    public int balas = 6;
    public float tiempo;
    public float tiemporecarga = 2;

    // Start is called before the first frame update
    void Start()
    {
        disparar.Enable();
        recargar.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (disparar.triggered && balas > 0)
        {
            GameObject newbala = Instantiate(modbala);
            newbala.transform.position = gameObject.transform.position;
            newbala.transform.up = new Vector3(Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x, Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y);
            balas--;
        }
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
        }
        if (recargar.triggered && tiempo <= 0)
        {
            balas = 6;
            tiempo = tiemporecarga;
        }

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
