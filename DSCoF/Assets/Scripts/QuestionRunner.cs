using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionRunner : MonoBehaviour
{
    public Button[] buttons;
    public TMP_Text question;
    public TMP_Text questionNo;
    public TMP_Text[] options;
    private QuestionManager QM;
    private GuyController GC;
    private int numberOfQuestions;
    private int currentNum;
    void Start()
    {
        GC = GameObject.FindObjectOfType<GuyController>().GetComponent<GuyController>();
        QM = GameObject.FindObjectOfType<QuestionManager>().GetComponent<QuestionManager>();
        numberOfQuestions = QM.questions.Count;
        currentNum = 1;
        buttons[0].onClick.AddListener(delegate { OptionClicked(0); });
        buttons[1].onClick.AddListener(delegate { OptionClicked(1); });
        buttons[2].onClick.AddListener(delegate { OptionClicked(2); });
        buttons[3].onClick.AddListener(delegate { OptionClicked(3); });
    }

    void OptionClicked(int index)
    {
        QM.questions[currentNum-1].userAnswer = char.ConvertFromUtf32(index + char.ConvertToUtf32("A", 0));
        currentNum += 1;
        if (currentNum > numberOfQuestions) {
            SceneManager.LoadScene("Result");
            return;
        }
        GC.HandleAnswer(currentNum-2);
    }

    public void UpdateQuestion()
    {
        Question Q = QM.questions[currentNum-1];
        questionNo.text = "Question "+currentNum.ToString();
        question.text = Q.questionText;
        for (int i = 0; i < 4; i++) {
            options[i].text = Q.options[i];
        }
    }

    public void Disable()
    {
        question.text = "";
        questionNo.text = "";
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void Enable()
    {
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].gameObject.SetActive(true);
        }
    }
}
