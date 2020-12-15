using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private float Rotatespeed = 10.0f;

    [SerializeField]
    private GameObject Explosion;

    private Spawn _spawn;


    void Start()
    {
        _spawn = GameObject.Find("Spawn").GetComponent<Spawn>();


    }

    
    void Update()
    {
        transform.Rotate(Vector3.forward * Rotatespeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lazer")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);


            Destroy(other.gameObject);

            _spawn.StartSpawning();


            Destroy(this.gameObject);

        }

    }


}
