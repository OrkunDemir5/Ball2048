using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    private BannerView bannerView;
    
    void Start()
    {
        
        this.RequestBanner();
    }


    void RequestBanner()
    {
        // Test ca-app-pub-3940256099942544/6300978111
        // orjinal  ca-app-pub-5927718770394793/4246027846
#if UNITY_ANDROID
        string reklamID = "ca-app-pub-5927718770394793/4246027846";
#elif UNITY_IPHONE
        string reklamID = "ca-app-pub-5927718770394793/1933034746";
#else
        string reklamID = "unexpected_platform";
#endif

        
        this.bannerView = new BannerView(reklamID, AdSize.Banner,AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

    }
}
