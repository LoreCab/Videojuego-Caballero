using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Seleccionar : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Pantalla de Juego");
    }

     public void Desarrollador()
    {
        SceneManager.LoadScene("Desarrollador");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    /*  IEnumerator Ingresar()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Desarrollador");
    }  */
}
