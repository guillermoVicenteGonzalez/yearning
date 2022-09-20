using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class SemaphoreValue : ScriptableObject
{
    public int valorInicial;
    public int valor = 0;

    public void OnBeforeSerialize()
    {
        valor = 0;
    }

    public void OnAfterDeserialize()
    {
        valor = 0;
    }

}
