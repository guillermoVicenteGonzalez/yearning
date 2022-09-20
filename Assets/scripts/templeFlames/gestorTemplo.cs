using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestorTemplo : MonoBehaviour
{
    public int indice;
    public GameObject[] altares;
    public bool[] resultados;
    public AudioClip[] sonidos;
    public GameObject cinematica;
    // Start is called before the first frame update
    void Start()
    {
        resultados = new bool[3];
        foreach(bool i in resultados)
        {
            i.Equals(false);
        }
        indice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        foreach(GameObject i in altares)
        {
            i.GetComponent<flamePostScript>().resetAnimation();
            i.GetComponent<flamePostScript>().activo = false;
        }
        indice = 0;
    }

    public void updateIndex(int posicion, bool resultado)
    {
        resultados[posicion] = resultado;
        altares[posicion].GetComponent<flamePostScript>().sonidoFuego(sonidos[indice]);
        indice++;
        if(indice >= 3)
        {
            if(resultados[0] && resultados[1] && resultados[2])
            {
                succesMethod();
            }
            else
            {
                Reset();
            }
        }
    }

    public void succesMethod() {
        cinematica.SetActive(true);
        StartCoroutine(apagarAltares());
    }

    public IEnumerator apagarAltares()
    {
        yield return new WaitForSeconds(10);
        foreach(GameObject i in altares)
        {
            i.GetComponent<flamePostScript>().succes();
        }
    }


}
