using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuLoader : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
