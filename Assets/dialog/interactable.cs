using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject panel;
    public Collider2D bounds;
    public item objeto;
    public bool playerInRange;
    public AudioClip accept;


    public void Start()
    {
        bounds = GetComponent<Collider2D>();
        playerInRange = false;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange)
        {
        
            if (!panel.activeInHierarchy)
            {
                FindObjectOfType<player>().currentState = PlayerState.Stop;
                this.gameObject.GetComponent<Renderer>().enabled = false;
                FindObjectOfType<player>().itemFound(objeto);
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
    public void TriggerDialogue()
    {
        FindObjectOfType<dialogManager>().StartDialogue(dialogue);
    }

    public void TriggerEndDialogue()
    {
        FindObjectOfType<dialogManager>().EndDialogue();
    }

    public void TriggerNextSentence()
    {
        FindObjectOfType<dialogManager>().DisplayNextSentence();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<player>().contextClue.SetActive(true);
            playerInRange = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            playerInRange = false;
            collision.GetComponent<player>().contextClue.SetActive(false);
            TriggerEndDialogue();
            //panel.SetActive(false);
        }
    }

    public IEnumerator addItem()
    {
        FindObjectOfType<player>().addItemToInventory(objeto);
        FindObjectOfType<player>().currentState = PlayerState.normal;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
        panel.SetActive(false);
    }
    
}
