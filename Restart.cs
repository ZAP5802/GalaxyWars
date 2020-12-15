using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Restart : MonoBehaviour
{

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
