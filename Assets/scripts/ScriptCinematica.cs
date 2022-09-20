using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCinematica : MonoBehaviour
{
    public  boolValue cinematicaActiva;
    public GameObject cinematica;
    //pruebas
    [SerializeField] private static bool boolActivarCinematica = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Awake()
    {
        if (boolActivarCinematica == true)
        {
            cinematica.SetActive(true);
            //cinematicaActiva.valor = false;
            //cinematicaActiva.setValor(false);
            boolActivarCinematica = false;
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
