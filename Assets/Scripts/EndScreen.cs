using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
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
        else if (score == 0)
        {
            finalScoreText.text = "OH WOW!\nI didn't know someone could be THAT dumb!";
        }
    }
}
