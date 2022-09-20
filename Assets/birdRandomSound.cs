using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdRandomSound : MonoBehaviour
{
    public float soundWait;
    public AudioSource salidaAudio;
    public AudioClip sonido;

    // Start is called before the first frame update
    void Start()
    {
        salidaAudio.clip = sonido;
    }

    // Update is called once per frame
    void Update()
    {
        soundWait = Random.Range(3.0f, 10.0f);
        salidaAudio.PlayScheduled(soundWait);
    }


}
