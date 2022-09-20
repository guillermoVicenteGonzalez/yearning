using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestRoomTransition : MonoBehaviour
{
    public Vector2 playerPosition;
    public GameObject fadepanel;
    public float fadeWait;
    public GameObject jugador;
    public GameObject previousCamera;
    public GameObject newCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //StartCoroutine(FadeCo());
            //SceneManager.LoadScene(SceneToLoad);
            StartCoroutine(roomTransfer());
        }
    }

    public IEnumerator roomTransfer()
    {
        fadepanel.SetActive(true);
        jugador.GetComponent<player>().currentState = PlayerState.Stop;
        previousCamera.SetActive(false);
        newCamera.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        jugador.GetComponent<player>().changePosition(playerPosition);
        fadepanel.GetComponent<Animator>().SetBool("triggerFadeOut", true);
        yield return new WaitForSeconds(1f);
        fadepanel.SetActive(false);
        jugador.GetComponent<player>().currentState = PlayerState.normal;
    }
}
