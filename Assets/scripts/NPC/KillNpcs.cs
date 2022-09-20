using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNpcs : MonoBehaviour
{
    public SemaphoreValue semaforo;
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
        if (collision.CompareTag("NPC"))
        {
            Destroy(collision.gameObject);
            semaforo.valor--;
        }
    }

}
