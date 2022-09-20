using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirCinematica : MonoBehaviour
{

    static bool created = false;
    public bool Loading = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
