using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ballController : MonoBehaviour
{

    public TMP_Text skor_txt;
    public static int skor;

    public List<ball> ballList = new List<ball>();
    public ball currentBall;
    public Transform spawnPoint;
    
    private Touch touch;
    private Vector3 downPos, upPos;
    private bool dragStarted;
    void Start()
    {
        skor = 0;
        currentBall = PickRandomBall();
   
        skor_txt.text = skor.ToString();
    }


    void Update()
    {
        skor_txt.text = skor.ToString();

        if (skor > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", skor);
        }     
        currentBall.tag = "Player";
        if (Input.touchCount > 0)
        {
            //ilk dokunduðun touch'ý al
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                upPos = touch.position;
                downPos = touch.position;
                
            }
        }
        if (dragStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                downPos = touch.position;
            }
            if (currentBall)
            {
                currentBall.rb.velocity = CalculateDirection() * 5; // 5 is speed
            }
            if (touch.phase == TouchPhase.Ended)
            {
                // fýrtlatma iþlemi

                downPos = touch.position;
                dragStarted = false;
                if (!currentBall) return;
                currentBall.rb.velocity = Vector3.zero;
                currentBall.SendBall();
                currentBall = null;
                StartCoroutine(SetBall());
            }
        }    
    }

    private IEnumerator SetBall()
    {
        yield return new WaitForSeconds(1);
        currentBall = PickRandomBall();
    }
    private ball PickRandomBall()
    {
        GameObject temp = Instantiate(ballList[Random.Range(0, ballList.Count)].gameObject, spawnPoint.position, Quaternion.identity);
        return temp.GetComponent<ball>();
    }
    private Vector3 CalculateDirection()
    {
        Vector3 temp = (downPos - upPos).normalized;
        temp.z = temp.x;
        temp.x = 0;
        temp.y = 0;
        return temp;
    }

   public void scoreArttirma()
    {
        skor += 5;
        skor_txt.text = skor.ToString();
    }
}
