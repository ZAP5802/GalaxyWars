using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private bool isgameover;
    
    
    private void Update()
        {
        if (CrossPlatformInputManager.GetButtonDown("Restart") && isgameover == true)
        {
            SceneManager.LoadScene(1);

        }
  
    }

    public void GameOver()
    {
        isgameover = true;

    }  
        
}

