using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // canvas kullanabilmemiz i�in gerekli

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    void Start()
    {

    }

    void Update()
    {
        UpdateScoreText();      
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;  
    }
}
