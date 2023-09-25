using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class arbitro : MonoBehaviour
{
    public TMP_Text vidas;
    public TMP_Text rondaActual;
    public TMP_Text canBalas;
    public TMP_Text canEne;
    public mov modmov;
    public personaje modperso;
    public int enemigos;
    public int ronda = 1;
    public float tiempo = 3;
    public float tiempoini = 3;

    // Start is called before the first frame update
    void Start()
    {
        modperso = FindObjectOfType<personaje>();
        modmov = FindObjectOfType<mov>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigos == 0)
        {

            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                ronda += 1;
                tiempo = tiempoini;
            }
        }
        if (modmov.vida <= 0 || ronda ==6)
        {
            SceneManager.LoadScene("postjuego");
        }
        canBalas.text = "balas: " + modperso.balas;
        vidas.text = "vida: " + modmov.vida;
        canEne.text = "enemigos: " + enemigos;
        rondaActual.text = "Ronda: " + ronda;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
