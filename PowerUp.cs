using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    
    [SerializeField]
    private int PowerUpID; // 0 - TRIPLE SHOT , 1 - SPEED , 2 - SHIELD

    [SerializeField]
    private AudioClip _clip;

    void Start()
    {

        transform.position = new Vector3(Random.Range(-8f, 8f), 11, 0);

    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);

        }
 
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player _player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);



            if( _player != null)
            
            {
                switch(PowerUpID)
                {
                    case 0:
                       
                        _player.TriplePowerShotActive();
                        UnityEngine.Debug.Log("Triple Shot is collected");
                        break;
                 
                    case 1:
                        
                        _player.SpeedBoost();
                        UnityEngine.Debug.Log("Speed boost is collected");
                        break;
                  
                    case 2:

                        _player.Shieldactive();

                        UnityEngine.Debug.Log("Shield is collected");
                        break;                                
                    
                    default:
                       
                        UnityEngine.Debug.Log("POWERING UP THE PLAYER");
                        break;


                }
           
            }
            Destroy(this.gameObject);

        }
    }


}

