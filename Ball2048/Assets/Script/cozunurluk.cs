using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cozunurluk : MonoBehaviour
{
    public Text genislik;
    public Text yukseklik;
    public Text enBoyOrani;

    public Camera Kamera;
    void Start()
    {

        Vector2 cozunurlukDegerleri = new Vector2(Screen.width, Screen.height);
        float ekranGenisligi = Screen.width;
        float ekranYuksekligi = Screen.height;
        float genislikYukseklikOrani = ekranGenisligi / ekranYuksekligi;
        float hedefOran = 16.0f / 9.0f;
        float EkranOrani = (float)Screen.width / (float)Screen.height;
        float EkranYuksekligi = EkranOrani / hedefOran;

        if (EkranYuksekligi < 1.0f)
        {
            Rect rect = Kamera.rect;
            rect.width = 1.0f;
            rect.height = EkranYuksekligi;
            rect.x = 0;
            rect.y = (1.0f - EkranYuksekligi) / 2.0f;
            Kamera.rect = rect;
        }
        else
        {
            float EkranGenisligi = 1.0f / EkranYuksekligi;
            Rect rect = Kamera.rect;
            rect.width = EkranGenisligi;
            rect.height = 1.0f;
            rect.x = (1.0f - EkranGenisligi) / 2.0f;
            rect.y = 0;
            Kamera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
