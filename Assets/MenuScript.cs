using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject buttonPlay;
    public GameObject buttonQuit;
    public bool isPaused;
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }
    public void PlayGame()
    {
        StartCoroutine(waitTime(tiempo));
        SceneManager.LoadScene("introduccion");
    }

    public void QuitGame()
    {
        StartCoroutine(waitTime(tiempo));
        Application.Quit();
        Debug.Log("Quit");
    }

    public void mainMenuScreen()
    {
        //Time.timeScale = 1f;
        StartCoroutine(waitTime(tiempo));
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume(){
        if (this.gameObject.activeInHierarchy)
        {
            isPaused = false;
            //Time.timeScale = 1f;
            //StartCoroutine(waitTime(tiempo));
            this.gameObject.SetActive(false);
            FindObjectOfType<player>().currentState = PlayerState.normal;
        }
    }

    public void Pause()
    {
        if (!this.gameObject.activeInHierarchy)
        {
            //Time.timeScale = 0f;
            //StartCoroutine(waitTime(tiempo));
            isPaused = true;
            this.gameObject.SetActive(true);
        }
    }

    private IEnumerator waitTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
