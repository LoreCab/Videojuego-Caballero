using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarZombie : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject positionObjct;
    public int totalEnemigos;
    bool band;
    void Start()
    {
        totalEnemigos = 0;
        band = true;
        Instantiate(enemyPrefab, positionObjct.transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        GameObject[] CantEnemigos = GameObject.FindGameObjectsWithTag("Zombie");

        totalEnemigos = CantEnemigos.Length;

        float t = Time.time;

        if (totalEnemigos < 5)
        {
            if (((int)t % 2) == 0 && band == true)
            {
                StartCoroutine(SpawnEnemy(1));
                band = false;
            }
        }
    }
    IEnumerator SpawnEnemy(int n)
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < n; i++)
        {
            Instantiate(enemyPrefab, positionObjct.transform.position, Quaternion.identity);
        }
        band = true; 
    }
    
}
