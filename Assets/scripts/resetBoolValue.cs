using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBoolValue : MonoBehaviour
{
    public boolValue booleano;
    // Start is called before the first frame update
    void Start()
    {
        //booleano.valor = true;
        booleano.setValor(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
