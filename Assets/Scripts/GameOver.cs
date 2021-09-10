using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int MaxScore;
    public Text Score;
    void Start(){
        MaxScore = PlayerPrefs.GetInt("MaxScore");
    }
    
    void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.name == "Zombie(Clone)")
            {
                if(MaxScore < int.Parse(Score.text))
                {
                    PlayerPrefs.SetInt("MaxScore", int.Parse(Score.text));
                }
                PlayerPrefs.SetInt("LastScore", int.Parse(Score.text));
                SceneManager.LoadScene("Final");
            }
    }
}
