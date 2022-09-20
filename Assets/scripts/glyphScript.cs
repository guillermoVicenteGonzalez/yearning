using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glyphScript :dialogable
{
    public Dialogue secretDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Submit") && playerInRange)
        {
            if (!panel.activeInHierarchy)
            {
                FindObjectOfType<player>().currentState = PlayerState.Stop;
                panel.SetActive(true);
                if (FindObjectOfType<player>().playerInventory.containsItemByName("dictionary"))
                {
                    TriggerSecretDialogue();
                }
                else
                {
                    TriggerDialogue();
                }
            }
            else
            {

                if (FindObjectOfType<dialogManager>().sentences.Count == 0)
                {
                    StartCoroutine(resetPanel());
                    FindObjectOfType<player>().currentState = PlayerState.normal;
                }
                TriggerNextSentence();
            }
        }
    }

    public void TriggerSecretDialogue()
    {
        FindObjectOfType<dialogManager>().StartDialogue(secretDialog);
    }
}
