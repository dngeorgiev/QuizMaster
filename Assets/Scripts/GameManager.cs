using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        StartQuiz();
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            EndQuiz();
            endScreen.ShowFinalScore();
        }
    }

    void StartQuiz()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    void EndQuiz()
    {
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(true);
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
