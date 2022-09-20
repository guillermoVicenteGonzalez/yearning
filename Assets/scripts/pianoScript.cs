using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoScript : dialogable
{
    public AudioSource audiosource;
    public AudioClip sonido;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange)
        {
            FindObjectOfType<player>().contextClue.SetActive(false);
            StartCoroutine(playSoundAndWait());
            
        }
    }

    public IEnumerator playSoundAndWait()
    {
        audiosource.PlayOneShot(sonido);
        FindObjectOfType<player>().currentState = PlayerState.Stop;
        FindObjectOfType<player>().animadorl.SetBool("isMoving", false);
        yield return new WaitForSeconds(6);
        FindObjectOfType<player>().currentState = PlayerState.normal;
        FindObjectOfType<player>().contextClue.SetActive(true);
    }
}
