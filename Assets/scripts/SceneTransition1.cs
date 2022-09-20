using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition1 : MonoBehaviour
{
    public string SceneToLoad;
    //la posicion en la que aparecerá
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel,Vector3.zero,Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(SceneToLoad);
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncoperation = SceneManager.LoadSceneAsync(SceneToLoad);
        while (!asyncoperation.isDone)
        {
            yield return null;
        }
    }
}
