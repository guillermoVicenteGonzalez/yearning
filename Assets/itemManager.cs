using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public Inventory playerInventory;
    public interactable[] sceneItems;
    void Start()
    {
        foreach( interactable i in sceneItems)
        {
            if (playerInventory.containsItem(i.objeto)){
                //i.GetComponent<GameObject>().SetActive(false);
                i.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
