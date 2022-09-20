using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public bool disableOnce;

    // Start is called before the first frame update

    void playSound(AudioClip sonido)
    {
        if (!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(sonido);
        }
        else
        {
            disableOnce = false;
        }
    }
}
