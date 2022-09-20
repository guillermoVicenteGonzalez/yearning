using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject panel;
    public Collider2D bounds;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<Collider2D>();
        playerInRange = false;
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
                TriggerDialogue();
            }
            else
            {
                if (FindObjectOfType<dialogManager>().sentences.Count == 0)
                {
                    StartCoroutine(resetPanel());
                }
                TriggerNextSentence();
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            collision.GetComponent<player>().contextClue.SetActive(true);
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
    public IEnumerator resetPanel()
    {
        FindObjectOfType<player>().currentState = PlayerState.normal;
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }

    }
