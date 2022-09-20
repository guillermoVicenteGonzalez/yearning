using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text dialogueText;
    public Animator animadorl;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animadorl.SetBool("isOpen", true);
        Debug.Log("Starting conversation with" + dialogue.name);

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
      
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentece)
    {
        dialogueText.text = "";
        foreach (char letter in sentece.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animadorl.SetBool("isOpen", false);
        Debug.Log("ending dialogue");
    }
}
