using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;

    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            quizManager.Correct();
            Debug.Log("Correcto");
        }
        else
        {
            quizManager.wrong();
            Debug.Log("Incorrecto");
        }
    }
}
