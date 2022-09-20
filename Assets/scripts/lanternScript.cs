using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternScript : interactable
{

    public GameObject lanternLight;


    public void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange)
        {
            if (!panel.activeInHierarchy)
            {
                FindObjectOfType<player>().currentState = PlayerState.Stop;
                this.gameObject.GetComponent<Renderer>().enabled = false;
                lanternLight.SetActive(false);
                FindObjectOfType<player>().itemFound(objeto);
                FindObjectOfType<player>().lanterLight.SetActive(true);
                panel.SetActive(true);
                TriggerDialogue();
            }
            else
            {
                if (FindObjectOfType<dialogManager>().sentences.Count == 0)
                {
                    StartCoroutine(addItem());
                    FindObjectOfType<player>().itemFoundFinish();
                    //panel.SetActive(false);
                }
                TriggerNextSentence();
            }

            //StartCoroutine(addItem(collision));
            //collision.GetComponent<player>().addItemToInventory(objeto);
            //Debug.Log("añado objeto");
            //this.gameObject.SetActive(false);
        }

    }
  

}
