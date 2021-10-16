using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    private QuestionManager QM;
    private int score;
    void Awake()
    {
        // QM = GameObject.FindObjectsOfType<QuestionManager>()[0].GetComponent<QuestionManager>();
        score = 0;
    }

    void Start()
    {
        for (int i = 0; i < QM.questions.Count; i++)
        {
            if (QM.questions[i].answer == QM.questions[i].userAnswer) {
                score += 1;
            }
        }

    }
}
