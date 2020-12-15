using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private float pos; 
    private float speed = 3.5f;


    void Update()
    {
        
        transform.Translate(Vector3.up * Time.deltaTime* speed );
        
        pos = transform.position.y;
       
        if (pos >=  9f)

        {

            if (transform.parent != null)
                Destroy(transform.parent.gameObject);

            
            Destroy(this.gameObject);


        }
    }



}

