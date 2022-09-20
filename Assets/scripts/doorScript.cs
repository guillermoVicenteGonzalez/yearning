using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : dialogable
{
    public item[] objetosNecesarios;
    public bool condicion;
    [SerializeField] bool isOpen;
    private Animator animadorl;
    public  GameObject doorSceneTransition;
    public GameObject doorCamera;
    public Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        
        condicion = false;
        isOpen = false;
        doorSceneTransition.SetActive(false);
        animadorl = GetComponent<Animator>();
        
    }


    
    void Update()
    {

        if (Input.GetButtonDown("Submit") && playerInRange && !isOpen)
        {
            if (FindObjectOfType<player>().playerInventory.containsItems(objetosNecesarios))
            {
                animadorl.SetBool("isOpen", true);
                StartCoroutine(playerStop());
                doorSceneTransition.SetActive(true);
                isOpen = true;
                collider.enabled = false;
            }else if (!panel.activeInHierarchy)
            {
                FindObjectOfType<player>().currentState = PlayerState.Stop;
                panel.SetActive(true);
                TriggerDialogue();
            }
            else
            {
                TriggerNextSentence();
                if (FindObjectOfType<dialogManager>().sentences.Count == 0)
                {
                    StartCoroutine(resetPanel());
                }
            }
        }
    }

    public IEnumerator playerStop()
    {

        FindObjectOfType<player>().currentState = PlayerState.Stop;
        yield return new WaitForSeconds(1);
        FindObjectOfType<player>().currentState = PlayerState.normal;

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if(!isOpen) collision.GetComponent<player>().contextClue.SetActive(true);
            doorCamera.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            collision.GetComponent<player>().contextClue.SetActive(false);
            doorCamera.SetActive(false);
        }
    }
}
