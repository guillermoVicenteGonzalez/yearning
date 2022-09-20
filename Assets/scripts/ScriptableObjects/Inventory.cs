using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public List<item> lista;
    public void OnAfterDeserialize()
    {
        lista.Clear();
    }

    public void OnBeforeSerialize()
    {

    }

    public bool containsItem(item objeto)
    {
        foreach( item i in lista)
        {
            if (i.Equals(objeto))
            {
                return true;
            }
        }
        return false;
    }

    public bool containsItems(item[] objetos)
    {
        foreach(item i in objetos)
        {
            if (!containsItem(i))
            {
                return false;
            }
        }
        return true;
    }

    public bool containsItemByName(string nombre)
    {
        foreach (item i in lista)
        {
            if (i.nombre.Equals(nombre))
            {
                return true;
            }
        }
        return false;
    }
}
