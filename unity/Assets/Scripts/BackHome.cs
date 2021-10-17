using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackHome : MonoBehaviour
{
    public Button homeButton;
    private QuestionManager QM;
    void Start()
    {
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
        // TODO
    }
}
