using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityStandardAssets.CrossPlatformInput;


public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string store_id = "3710715";
   
    private string banner_ads = "Natural_Ads";

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);


        }
    }
    
    
    
    
    void Start()
    {
        StartCoroutine(CallAd());


        
        Monetization.Initialize(store_id ,false);
        
    }

    public  void ShowBannerAd()
    {
            if (Monetization.IsReady(banner_ads))
            {
                ShowAdPlacementContent ad = null;

                ad = Monetization.GetPlacementContent(banner_ads) as ShowAdPlacementContent;

                if (ad != null)
                {
                    ad.Show();

                }
            }


    }

IEnumerator  CallAd()
    {
        yield return new WaitForSeconds(25.0f);

        ShowBannerAd();

    }


}
