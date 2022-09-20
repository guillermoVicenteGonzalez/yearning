using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class boolValue : ScriptableObject
{
    [SerializeField] private static bool valor;

    public void setTrue()
    {
        valor.Equals(true);
    }

    public bool getValor()
    {
        return valor;
    }

    public void setValor(bool nuevoValor)
    {
        valor = nuevoValor;
    }
    /*
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    */
}