using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript :dialogable
{
    public Dialogue secretDialog;
    public Animator animadorl;
    public GameObject cinematica;
    public bool isOpen;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        animadorl = GetComponent<Animator>();
        isOpen = false;
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
                if (playerInventory.containsItemByName("musicSheet") && playerInventory.containsItemByName("accordion"))
                {
                    isOpen = true;
                    TriggerSecretDialogue();
                    FindObjectOfType<player>().contextClue.SetActive(false);
                    cinematica.SetActive(true);
                    animadorl.SetBool("down", true);
                    FindObjectOfType<player>().currentState = PlayerState.normal;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen)
        {
            if (collision.CompareTag("Player"))
            {
                playerInRange = true;
                collision.GetComponent<player>().contextClue.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            collision.GetComponent<player>().contextClue.SetActive(false);
        }
    }

    public void TriggerSecretDialogue()
    {
        FindObjectOfType<dialogManager>().StartDialogue(secretDialog);
    }
}
