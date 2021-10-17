using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackHome : MonoBehaviour
{
    public Button homeButton;
    private QuestionManager QM;
    private ServerCommunicator SC;
    void Start()
    {
        SC = GameObject.FindObjectsOfType<ServerCommunicator>()[0].GetComponent<ServerCommunicator>();
        QM = GameObject.FindObjectsOfType<QuestionManager>()[0].GetComponent<QuestionManager>();
        homeButton.onClick.AddListener(ReturnHome);
    }

    void ReturnHome()
    {
        SendData();
        SceneManager.LoadScene("MainMenu");
    }

    void SendData()
    {
        for (int i = 0; i < QM.questions.Count; i++) {
            SC.Post(QM.questions[i].QID, QM.questions[i].userAnswer[0]);
        }
    }
}
