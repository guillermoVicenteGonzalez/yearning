using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typewriter : MonoBehaviour
{
    [TextArea(3, 10)]
    public string TextoParaEscribir;
    public TMP_Text etiqueta;
    public float speed;
    // Start is called before the first frame update
    public void run(string texto)
    {
        StartCoroutine(typeText(TextoParaEscribir, etiqueta));
    }

    public void OnEnable()
    {
        run(TextoParaEscribir);
    }

    private IEnumerator typeText(string textToType, TMP_Text textLabel)
    {

        float t = 0;
        int charIndex = 0;
        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * speed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }

        textLabel.text = textToType;
    }


    
}
