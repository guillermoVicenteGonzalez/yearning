using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamePostScript : dialogable
{
    public gestorTemplo gestor;
    public int id;
    public bool activo;
    public Animator animadorl;
    public AudioSource salidaAudio;
    // Start is called before the first frame update
    void Start()
    {
        activo = false;
        animadorl = GetComponent<Animator>();
        salidaAudio = GetComponent<AudioSource>();
        salidaAudio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange)
        {
            if (!activo)
            {
                FindObjectOfType<player>().currentState = PlayerState.Stop;
                activo = true;
                encender();
                FindObjectOfType<player>().currentState = PlayerState.normal;
            }
        }
    }

    public void encender()
    {
        switch (gestor.indice)
        {
            case 0:
                animadorl.SetBool("isLit", true);
                animadorl.SetInteger("indice", 0);
                break;

            case 1:
                animadorl.SetBool("isLit", true);
                animadorl.SetInteger("indice", 1);
                break;

            case 2:
                animadorl.SetBool("isLit", true);
                animadorl.SetInteger("indice", 2);
                break;
        }
        if(id == gestor.indice)
        {
            gestor.updateIndex(id, true);
        }
        else
        {
            gestor.updateIndex(id, false);
        }
    }

    public void resetAnimation()
    {
        animadorl.SetBool("isLit", false);
        salidaAudio.Stop();
    }

    public void sonidoFuego(AudioClip sonido)
    {
        salidaAudio.loop = true;
        salidaAudio.clip = sonido;
        salidaAudio.volume = 0;
        salidaAudio.Play();
        StartCoroutine(startAudio());
    }

    public void succes()
    {
        StopAllCoroutines();
        activo = true;
        StartCoroutine(stopAudio());
    }

    public IEnumerator startAudio()
    {
        salidaAudio.volume = 0;
        for (salidaAudio.volume = 0; salidaAudio.volume <= 1; salidaAudio.volume += 0.01f)
        {
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator stopAudio()
    {
        for (salidaAudio.volume=salidaAudio.volume; salidaAudio.volume >= 0.1; salidaAudio.volume = salidaAudio.volume - 0.01f)
        {
            yield return new WaitForSeconds(0.05f);
        }
        //animadorl.SetBool("isLit", false);
        resetAnimation();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!activo)
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
}
