using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]

    private Text Score_text;

    [SerializeField]

    private Text BestScore_txt;

    [SerializeField]

    private Image livesimg;
    
    [SerializeField]

    private Text gameovertext;

    [SerializeField]
    private Button Restart;

    public int Highscore ;

    public int player_score ; 

    [SerializeField]

    private Sprite[] _livesSprites;

    [SerializeField]

    private Text RestartText;

    private  GameManager   gameManager;

    void Start()
    {

        gameovertext.gameObject.SetActive(false);
        Score_text.text = "Score: " + 0 ;
        Highscore = PlayerPrefs.GetInt("HighScore" , 0);
        BestScore_txt.text = "Best Score : " + Highscore;


        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(gameManager == null)
        {
            UnityEngine.Debug.LogError("Game Manager is not found");

        }
    
    }


    public void UpdateScore(int playerscore)
    {
        Score_text.text = "Score: " + playerscore ;
   
        player_score = playerscore;
        
        UnityEngine.Debug.Log(player_score);
    }
   
    public void checkforbestscore()
    {
        if(player_score > Highscore)
        {
            Highscore = player_score;
           
            PlayerPrefs.SetInt("HighScore", Highscore);

            BestScore_txt.text = "Best Score :" + Highscore;

        }
   
    }
   


    public void UpdateLives(int Currentlives)
    {

        livesimg.sprite = _livesSprites[Currentlives];

        if ( Currentlives == 0)
        {
            gameoversequence();
           
        }

    }

    void gameoversequence()
    {
        gameManager.GameOver();
        gameovertext.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);
        StartCoroutine(gameoverflickerRoutine());
    }

    IEnumerator gameoverflickerRoutine()
    {
        while (true)
        {
            gameovertext.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            gameovertext.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }



}
