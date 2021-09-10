using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject Bullet;
    float speed = 50;
    private GameObject CamTransform;
    public Text Puntostxt;

    void Start() {

        goal = Camera.main.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        Puntostxt=GameObject.Find("Puntos").GetComponent<Text>();
        
    }

    void Update() {
        agent.destination = goal.position;
        CamTransform = GameObject.FindGameObjectWithTag("Camera_Root");
        GameObject[] Balas = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < Balas.Length; i++)
        {
            Destroy(Balas[i], 1);
        }
    }
    public void Morir(Collider col)
    {
        StartCoroutine(Matar(col));

    }

    IEnumerator Matar(Collider col)
    {
        //Espera 2 segundos antes de matar al zombie
        yield return new WaitForSeconds(2);

        //Genera la bala y la pone en la direccion que tiene que ir
        GameObject go = Instantiate(Bullet);
        go.transform.position = CamTransform.transform.position;
        go.transform.rotation = CamTransform.transform.rotation;
        go.GetComponent<Rigidbody>().velocity = goal.forward * speed;

        GetComponent<CapsuleCollider>().enabled = false;
        //El zombie deja de moverse y cae muerto
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("Z_FallingBack");
        Camera.main.GetComponent<AudioSource>().Play();

        //El zombie se desaparece despues de 2 segundos
        Destroy(gameObject, 1);
        Puntostxt.text = "" +(int.Parse(Puntostxt.text) + 10); 
        
    }

}
