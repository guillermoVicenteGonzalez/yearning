using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorNPC : MonoBehaviour
{
    //public GameObject cinematica;
    public GameObject prefab;
    public SemaphoreValue semaforo;
    private Vector2 coordenadas;
    public int tope;
    public float timer;
    public float timerValue;
    public bool stop;
    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        //timer = 0.3f;
        timer = timerValue;
        semaforo.valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop)
        {

                timer -= Time.fixedDeltaTime;
                if (timer <= 0f)
                {
                    semaforo.valor++;
                if (semaforo.valor < tope)
                {
                    coordenadas = new Vector2(Random.Range(-7.06f, 7.36f), 33f);

                    Instantiate(prefab, coordenadas, Quaternion.identity);
                    //timer = 0.3f;
                }
                    timer = timerValue;
                }
        }
    }

    void stopGenerating()
    {
        stop = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stopGenerating();
        }
    }


}
