using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        int score = scoreKeeper.CalculateScore();
        finalScoreText.text = "Congratulations!\n You got a score of " + score + "%";

        if (score == 69)
        {
            finalScoreText.text += " (lol)";
        }
    }
}
