using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject cinematica;
    public GameObject camara;
    public boolValue valorBooleano;
    public boolValue[] listaValoresCinematica;


    void Start()
    {
        valorBooleano.setValor(true);
        resetCinematicValues(listaValoresCinematica);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camara.SetActive(false);
            cinematica.SetActive(true);
        }
    }


    public void resetCinematicValues(boolValue[] lista)
    {
        foreach(boolValue i in lista)
        {
            //i.valor = true;
            i.setValor(true);
        }
    }

}
