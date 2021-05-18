using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public Button[] options;
    public int currentQuestion;

    public GameObject quizPanel;
    public GameObject guPanel;
    public Button buttonRetry;
    public Button buttonAvanzar;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;

    private int totalQuestions = 0;
    public int score;

    private AdVideo _AdVideo;
    
    // Start is called before the first frame update
    void Start()
    {
        _AdVideo = FindObjectOfType<AdVideo>();
        
        totalQuestions = QnA.Count;
        guPanel.SetActive(false);
        generateQuestion();
    }

    void GameOver()
    {
        quizPanel.SetActive(false);
        guPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
        if (score == 3)
        {
            buttonAvanzar.gameObject.SetActive(true);
            buttonRetry.gameObject.SetActive(false);
        }
        else
        {
            buttonRetry.gameObject.SetActive(true);
            buttonAvanzar.gameObject.SetActive(false);
        }
    }

    public void Retry()
    {
        _AdVideo.showVideo = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Question");
            GameOver();
        }
    }
}
