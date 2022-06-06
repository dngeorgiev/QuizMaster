using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite wrongAnswerSprite;

    //int correctAnswerIndex;

    void Start()
    {
        GetNextQuestion();
        //DisplayQuestion();
    }

    void GetNextQuestion()
    {
        SetButtonsState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    void SetButtonsState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        int correctAnswerIndex = question.GetCorrectAnswerIndex();
        Image buttonImage = answerButtons[index].GetComponent<Image>();

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";

            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            Image correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "You idiot! Correct answer is:\n" + correctAnswer;

            correctButtonImage.sprite = correctAnswerSprite;
            buttonImage.sprite = wrongAnswerSprite;
        }

        SetButtonsState(false);
    }
}