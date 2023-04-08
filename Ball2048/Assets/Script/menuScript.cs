using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class menuScript : MonoBehaviour
{

    public GameObject music;
    private InterstitialAd interstitial;

    public void PlayButton()
    {       
      SceneManager.LoadScene(1); 
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MusicOff()
    {
        music.SetActive(false);
    }


}
