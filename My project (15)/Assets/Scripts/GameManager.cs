using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //oyuncunun ba�lama noktas�
    public Transform startingPoint;

    //lerp h�z�
    public float lerpSpeed;

    //oyuncunun y�ksek skoru
    public float highScore = 0;

    //oyuncunun anl�k skoru
    public float score = 0;

    //skoru g�steren metin nesneleri
    public TextMeshProUGUI TotalScoreText;
    public TextMeshProUGUI HighScoreText;

    private bool isNextLevel = true;
    
    PlayerController playerControllerScript;

    private void Start()
    {
        //y�ksek skoru oyuncu tercihlerinden al
        highScore = PlayerPrefs.GetFloat("EnYuksekSkorum", 0);

        //skoru ve y�ksek skoru ekranda g�ster
        TotalScoreText.text = "SCORE:" + score;
        HighScoreText.text = "HIGHSCORE:" + highScore;

        //oyuncu kontrolleini al ve oyunu ba�lat
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.gameOver = false;
        StartCoroutine(PlayerIntro());
    }

    private void Update()
    {
        HighScoreText.text = "HIGHSCORE:" + highScore.ToString();

        if (score >= 50 && isNextLevel)
        {
            isNextLevel = false;
            Debug.Log("sdfgsdf 000 ");
            NextLevel();
        }
       
        if (score >= 50)
        {
            Time.timeScale = 1.3f; 
        }
        if (score >= 100)
        {
            Time.timeScale = 1.5f; 
        }
        if (score >= 150)
        {
            Time.timeScale = 1.7f; 
        }
        if (score >= 200)
        {
            Time.timeScale = 1.9f; 
        }
        if (score >= 250)
        {
            Time.timeScale = 2f; 
        }
        if (score >= 300)
        {
            Time.timeScale = 2.3f; 
        }
    }

    IEnumerator PlayerIntro()
    {
        //Intro animasyonu i�in ba�lang�� ve biti� pozisyonular�
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;

        //Intro animasyonunun uzunlu�u
        float journeyLength = Vector3.Distance(startPos, endPos);

        //intro animasyonunun ba�lang�� zaman�
        float startTime = Time.time;

        //intro animasoynunun ne kadar s�rede tamamland���
        float distanceCov = (Time.time - startTime) / lerpSpeed;
        float fractionJourney = distanceCov / journeyLength;

        //intro animasyonunun lerp ile oynat
        while (fractionJourney < 1)
        {
            distanceCov = (Time.time - startTime) * lerpSpeed;
            fractionJourney = distanceCov / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionJourney);
            yield return null;
        }

        //intro sona erdi�inde oyunu devam ettirir
        playerControllerScript.gameOver = false;
    }

    //skor eklemek i�in metod
    public void AddScore(int value)
    {
        //skoru g�ncelle ve y�ksek skoru kontrol et
        score += value;
        TotalScoreText.text = "SCORE: " + score;

        if (score >= highScore)
        {
            highScore = score;
            HighScoreText.text = "HIGHSCORE: " + highScore;

            //yeni y�ksek skoru dataya kaydet
            PlayerPrefs.SetFloat("EnYuksekSkorum", highScore);
        }
        else
        {
            HighScoreText.text = "HIGHSCORE: " + highScore;
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
