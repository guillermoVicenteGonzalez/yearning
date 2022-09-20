using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    normal,
    Stop
}

public class player : MonoBehaviour
{

    public float velocidad;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Animator animadorl;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] MenuScript menuScript;
    [SerializeField] MenuButtonController controladorBoton;
    public VectorValue startingPosition;
    private bool isPaused;
    public GameObject contextClue;
    public GameObject theItemFound;
    public Inventory playerInventory;
    public GameObject lanterLight;
    public bool isLightRoom;


    public bool lightSwitch;

    public PlayerState currentState;



    /*
     * que es normalize?. Si presionas izquierda y arriba a la vez, las velocidades se suman.
     * Para evitar esto y que el personaje vaya a una velocidad normal hay que normalizar el vector
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animadorl = GetComponent<Animator>();
        menuScript = pauseMenu.GetComponent<MenuScript>();
        controladorBoton = pauseMenu.GetComponent<MenuButtonController>();
        menuScript.isPaused = false;

        //muevo al jugador al valor del scriptable object
        transform.position = startingPosition.initialValue;
        currentState = PlayerState.normal;


        if (isLightRoom && playerInventory.containsItemByName("farol"))
        {
            lanterLight.SetActive(true);
        }
        else
        {
            lanterLight.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        //sin raw, al ir a la izquierda y luego a la derecha primero restaria a la y hasta llegar al 1
        //axis raw pasa de 0 a -1 o 1 directamente
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Cancel"))
        {
            
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.GetComponent<MenuScript>().Resume();
                currentState = PlayerState.normal;
            }
            else
            {
                currentState = PlayerState.Stop;
                pauseMenu.GetComponent<MenuScript>().Pause();
            }
        }
        if (!menuScript.isPaused) { 
            updateAnimationAndMove();
        }
        if (Input.GetButtonDown("light"))
        {
            if (playerInventory.containsItemByName("farol")){
                if (lightSwitch)
                {
                    lanterLight.SetActive(true);
                    lightSwitch = false;
                }
                else
                {
                    lanterLight.SetActive(false);
                    lightSwitch = true;
                }
            }
        }


    }

    void updateAnimationAndMove()
    {
        if (currentState != PlayerState.Stop)
        {
            if (change != Vector3.zero)
            {
                change.x = Mathf.Round(change.x);
                change.y = Mathf.Round(change.y);
                change = change.normalized;
                moveCharacter();
                animadorl.SetFloat("moveX", change.x);
                animadorl.SetFloat("moveY", change.y);
                animadorl.SetBool("isMoving", true);
            }
            else
            {
                animadorl.SetBool("isMoving", false);
            }
        }
    }

    private void moveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * velocidad * Time.fixedDeltaTime);
    }

    public void addItemToInventory(item objeto)
    {
        if (!playerInventory.lista.Contains(objeto))
        {
            playerInventory.lista.Add(objeto);
        }
    }

    public void itemFound(item objeto)
    {
        contextClue.SetActive(false);
        theItemFound.GetComponent<SpriteRenderer>().sprite = objeto.image;
        animadorl.SetBool("isItemFound", true);
        theItemFound.SetActive(true);
    }

    public void itemFoundFinish()
    {
        animadorl.SetBool("isItemFound", false);
        theItemFound.SetActive(false);
    }

    public void changePosition(Vector2 nuevaPosicion)
    {
        myRigidbody.position = nuevaPosicion;
    }
}
