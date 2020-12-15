
using System.Collections;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    private Player _player;

    private Animator _anim;

    private AudioSource audioSource;


    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (_anim == null)
        {
            UnityEngine.Debug.LogError("Animator not found ");

        }




        transform.position = new Vector3(Random.Range(-8f,8f), 10, 0);
    }


    void Update()
    {

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= -9)
        {
            float random = Random.Range(-8f, 8f);
    
            transform.position = new Vector3(random, 6, 0);
                   
        
        }





    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Hit: " + other.transform.name);


        if (other.tag == "Lazer")
        {
            
            if (_player != null)
            {
                _player.Addscore(10);

            }
            _speed = 0;

            _anim.SetTrigger("Enemy_Death");

            audioSource.Play();

            Destroy(this.gameObject , 0.5f);
            
            Destroy(other.gameObject);
            
            
        }

        if(other.tag =="Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if (player != null) //to check if player really exists ( good for us )
            {
                player.Damage();

            }
            _speed = 0;
            _anim.SetTrigger("Enemy_Death");
            audioSource.Play();


            Destroy(this.gameObject , 0.5f );

        }

            
        

    }

}
