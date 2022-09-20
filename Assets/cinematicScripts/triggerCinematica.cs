using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCinematica : MonoBehaviour
{
    public boolValue interruptor;
    public GameObject cinematica;
    //pruebas
    [SerializeField] private static bool boolCinematicaActiva = true;
    // Start is called before the first frame update
    public void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        cinematica.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && boolCinematicaActiva == true)
        {
            Debug.Log("entro en el if");
            cinematica.SetActive(true);
            //interruptor.valor = false;
            //interruptor.setValor(true);
            boolCinematicaActiva = false;
        }
        else
        {
            cinematica.SetActive(false);
        }
    }
}
