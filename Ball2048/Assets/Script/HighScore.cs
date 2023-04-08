using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighScore : MonoBehaviour
{
    public TMP_Text _highScoreText;
    void Start()
    {
        _highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }
}
