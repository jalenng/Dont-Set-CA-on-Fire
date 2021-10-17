using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private QuestionManager QM;
    private int score;

    void Start()
    {
        QM = GameObject.FindObjectsOfType<QuestionManager>()[0].GetComponent<QuestionManager>();
        score = 0;
        for (int i = 0; i < QM.questions.Count; i++)
        {
            if (QM.questions[i].answer.Trim() == QM.questions[i].userAnswer.Trim()) {
                score += 1;
            }
        }
        scoreText.text = "You Got "+score.ToString()+" Points!";
    }
}
