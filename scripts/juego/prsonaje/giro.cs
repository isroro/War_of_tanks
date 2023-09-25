using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giro : MonoBehaviour
{
    public mov movim;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        movim = FindObjectOfType<mov>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movactu = movim.movi.ReadValue<Vector2>();
        //var angle = Mathf.Atan2(movactu.y, movactu.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        anim.SetFloat("velocidadFrontal", movactu.y * 10);
        anim.SetFloat("velocidadLateral", movactu.x * 10);
          
    }
}
