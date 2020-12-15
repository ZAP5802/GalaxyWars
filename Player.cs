using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] // to show the variable in engine and adjust it even if it is a private variable

    private float _speed = 0.75f;

    [SerializeField]
    private GameObject LaserPrefab;

    [SerializeField]
    private float _firerate = 0.5f;

    private float _canfire = -1f;

    [SerializeField]

    private int _lives = 3;

    private Spawn spawn;

    [SerializeField]
    private bool istripleshotactive;

    [SerializeField]
    private GameObject TripleLazer;

    [SerializeField]
    private float Speedmultiplier = 2;


    [SerializeField]
    private bool isspeedboostactive = false;


    [SerializeField]
    private bool isshieldactive = false;

    [SerializeField]
    private GameObject ShieldVisuals;

    [SerializeField]
    private GameObject Right_engine;

    [SerializeField]
    private GameObject Left_engine;

    [SerializeField]
    private int score;

    private UI_Manager UI;

    [SerializeField]
    private AudioClip LazerAudio;
    

    private AudioSource audioSource;


    void start() // executed once in start
    {
        spawn = GameObject.Find("Spawn").GetComponent<Spawn>();

        UI = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        audioSource = GetComponent<AudioSource>();
       
        if(audioSource == null )
        {
            UnityEngine.Debug.LogError("Audio source not found");

        }
        else
        {
            audioSource.clip = LazerAudio;

        }

        if (UI == null)
        {

            UnityEngine.Debug.LogError("The UI Manager is null");

        }



        transform.position = new Vector3(0, 0, 0);

    }


    void Update() // executed again and again 


    {
        playermovement();

        if (CrossPlatformInputManager.GetButtonDown("Fire") && Time.time > _canfire)
        {
            shootlazer();

        }

    }


    void playermovement()
    {
        float verticalinput = CrossPlatformInputManager.GetAxis("Vertical");

        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * _speed * verticalinput);


        if (transform.position.y >= 7)
        {
            transform.position = new Vector3(transform.position.x, 7, 0);
        }
        else if (transform.position.y <= -5)
        {
            transform.position = new Vector3(transform.position.x, -5, 0);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }

    void shootlazer()
    {


        _canfire = Time.time + _firerate; // time.time is like timer for how much time has it been since start of the game

        if (istripleshotactive == true)
        {
            Instantiate(TripleLazer, transform.position, Quaternion.identity);

        }

        else
        {

            Instantiate(LaserPrefab, transform.position + new Vector3(0, 1.15f, 0), Quaternion.identity);  //Instantiate is for spawning Quaternion is for spawning on the player  

        }
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();


    }

    public void Damage()
    {
       

        if (isshieldactive == true)
        {
            isshieldactive = false;
          
            ShieldVisuals.SetActive(false);


            return;
        }



        _lives--;

        if(_lives == 2)
        {
            Left_engine.SetActive(true);

        }

        else if(_lives == 1)
        {
            Right_engine.SetActive(true);

        }

        UI = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        UI.UpdateLives(_lives);


        spawn = GameObject.Find("Spawn").GetComponent<Spawn>();

        

        if (_lives < 1)
        {

            spawn.OnPlayerDeath();

            UI.checkforbestscore();

            Destroy(this.gameObject);

        }


    }

    public void TriplePowerShotActive()
    {
        istripleshotactive = true;
        StartCoroutine(TripleshotpowerdownRoutine());

    }



    IEnumerator TripleshotpowerdownRoutine()
    {
        yield return new WaitForSeconds(6f);

        istripleshotactive = false;

    }


    public void SpeedBoost()
    {
        isspeedboostactive = true;
        _speed *= Speedmultiplier;

        StartCoroutine(SpeedBoostDown());

    }

    IEnumerator SpeedBoostDown()
    {
        yield return new WaitForSeconds(6f);

        isspeedboostactive = false;

        _speed /= Speedmultiplier;
    }


    public void Shieldactive()

    {
        isshieldactive = true;
        ShieldVisuals.SetActive(true);

    }


    public void Addscore(int points)
    {
        UI = GameObject.Find("Canvas").GetComponent<UI_Manager>();
       
        score += points ;
       
        UI.UpdateScore(score);

    }


}
