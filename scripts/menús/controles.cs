using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controles : MonoBehaviour
{
    public GameObject botoninicio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void inicio()
    {
        SceneManager.LoadScene("inicio");
    }
}
