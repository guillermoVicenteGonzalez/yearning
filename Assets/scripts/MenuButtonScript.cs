using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animadorl;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(menuButtonController.index == thisIndex)
        {
            animadorl.SetBool("selected", true);
            if(Input.GetAxis("Submit") == 1)
            {
                animadorl.SetBool("pressed", true);

            }else if (animadorl.GetBool("pressed"))
            {
                animadorl.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animadorl.SetBool("selected", false);
        }
    }

}
