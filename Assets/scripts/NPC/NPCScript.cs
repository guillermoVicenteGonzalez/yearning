using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private Rigidbody2D myRb;
    private Vector3 direccion;
    public float velocidad;
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        direccion = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        myRb.MovePosition(transform.position + direccion * velocidad * Time.fixedDeltaTime);
    }








}
