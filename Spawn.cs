using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private GameObject Container;

    [SerializeField]
    private bool _StopSpawning;

    [SerializeField]
    private GameObject[] PowerUp;




    void Start()
    {



    }

    public void StartSpawning()
    {
        StartCoroutine("SpawnTripleRoutine");

        StartCoroutine("SpawnRoutine");

    }



    public void OnPlayerDeath()
    {
        _StopSpawning = true;

    }


    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3.5f);


        while (_StopSpawning == false)
        {


            Vector3 pos = new Vector3(Random.Range(-8f, 8f), 7, 0);

            GameObject newenemy = Instantiate(EnemyPrefab, pos, Quaternion.identity);

            newenemy.transform.parent = Container.transform;

            yield return new WaitForSeconds(5.0f);


        }



    }


    IEnumerator SpawnTripleRoutine()
    {
        while (_StopSpawning == false)
        {
            Vector3 postospawn = new Vector3(Random.Range(-8f, 8f), 8, 0);
            int randomPower = Random.Range(0, 3);

            Instantiate(PowerUp[randomPower], postospawn, Quaternion.identity);


            yield return new WaitForSeconds(Random.Range(8, 12));


        }




    }

}

