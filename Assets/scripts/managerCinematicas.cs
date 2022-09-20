using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCinematicas : MonoBehaviour
{
    [SerializeField] private bool cinematicaInicial = true;
    [SerializeField] private bool cinematicaMuro = true;
    [SerializeField] private bool cinematicaBosque = true;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivateMuro()
    {
        cinematicaMuro = false;
    }

    public void deactivateBosque()
    {
        cinematicaBosque = false;
    }
}
