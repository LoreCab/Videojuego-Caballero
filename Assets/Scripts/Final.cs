using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public int SoundOf;
    public AudioSource Sound;
    public int Score;
    public GameObject _Panel;
    public Text LastScore;

    // Start is called before the first frame update
    void Start()
    {
        SoundOf = PlayerPrefs.GetInt("Sonido");
        Sound = GetComponent<AudioSource>();
        if(SoundOf == 1)
        {
            Sound.Pause();
            Sound.volume = 0;
        }
        else
        {
            Sound.Play();
            Sound.volume=1;
        }
        Score= PlayerPrefs.GetInt("MaxScore");
        LastScore.text = PlayerPrefs.GetInt("LastScore").ToString();
        if (int.Parse(LastScore.text) >= Score)
        {
            _Panel.SetActive(true);
        }
        else
        {
            _Panel.SetActive(false);
        }
    }

    public void Iniciar()
    {
        StartCoroutine(Espera());
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Pantalla de Juego");

    }

    public void Menu()
    {
        StartCoroutine(EsperaMenu());
    }

    IEnumerator EsperaMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("Sonido", 0);
    }
}
