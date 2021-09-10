using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    public GameObject _Panel;
    public AudioSource Sound;
    public GameObject _Toggle;
    public Text Score;
    public int SoundOf;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        _Toggle = GameObject.Find("Toggle");
        Score.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Iniciar()
    {
        StartCoroutine(Espera());
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Pantalla de Juego");

    }

    public void InfoIn()
    {
        _Panel.SetActive(true);
    }

    public void InfoOut()
    {
        StartCoroutine(Info());
    }

    IEnumerator Info()
    {
        yield return new WaitForSeconds(5);
        _Panel.SetActive(false);
    }

    public void Mute()
    {
        if (_Toggle.GetComponent<Toggle>().isOn)
        {
            _Toggle.GetComponent<Toggle>().isOn = false;
            Sound.Play();
            PlayerPrefs.SetInt("Sonido", 0);
        }
        else
        {
            _Toggle.GetComponent<Toggle>().isOn = true;
            Sound.Pause();
            PlayerPrefs.SetInt("Sonido", 1);
        }
    }
}
