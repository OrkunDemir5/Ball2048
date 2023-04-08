using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;

public class Destroyer : MonoBehaviour
{
    private InterstitialAd interstitial;

    public GameObject kaybettinPanel;
    public GameObject skorText;

    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitial();
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.tag = "Sphere";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();

            }
            kaybettinPanel.SetActive(true);
            skorText.SetActive(false);

        }
    }

    void RequestInterstitial()
    {
        // Test ca-app-pub-3940256099942544/1033173712
        // orjinal  ca-app-pub-5927718770394793/7993701160
#if UNITY_ANDROID
        string reklamID = "ca-app-pub-5927718770394793/7993701160";
#elif UNITY_IPHONE
        string reklamID = "ca-app-pub-5927718770394793/5309991219";
#else
        string reklamID = "unexpected_platform";
#endif


        this.interstitial = new InterstitialAd(reklamID);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

    }
}
