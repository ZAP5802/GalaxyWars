using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3.0f);

    }
 
    
}
