using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinematicaInicialMuro : MonoBehaviour
{
    public boolValue interruptor;
    public GameObject cinematica;
    //pruebas
    [SerializeField] private static bool boolCinematicaActiva = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        if (boolCinematicaActiva == false)
        {
            cinematica.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("esta en el area");
        if (collision.CompareTag("Player") && boolCinematicaActiva == true)
        {
            //interruptor.valor = false;
            //interruptor.setValor(false);
            boolCinematicaActiva = false;
            Debug.Log("estoy dentro del if");
            cinematica.SetActive(true);
        }
        else
        {
            cinematica.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
