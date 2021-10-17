using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public TMP_Text questionNumber;
    public TMP_Text questionText;
    public TMP_Text[] options;
    public GameObject[] bars;
    public TMP_Text[] percent;
    public Image[] arrows;
    public int maxWidth;
    public Button nextQuestion;
    public Button prevQuestion;

    private int qnum;
    private QuestionManager QM;


    void Start()
    {
        QM = GameObject.FindObjectOfType<QuestionManager>().GetComponent<QuestionManager>();
        nextQuestion.onClick.AddListener(ToNextQ);
        prevQuestion.onClick.AddListener(ToPrevQ);
        qnum = 1;
        prevQuestion.interactable = false;
        ShowQuestion();
    }

    void ToNextQ()
    {
        qnum += 1;
        prevQuestion.interactable = true;
        if (QM.questions.Count <= qnum) { nextQuestion.interactable = false; }
        ShowQuestion();
    }

    void ToPrevQ()
    {
        qnum -= 1;
        nextQuestion.interactable = true;
        if (qnum <= 1) { prevQuestion.interactable = false; }
        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question tmp = QM.questions[qnum-1];
        questionNumber.text = "Question "+qnum.ToString();
        questionText.text = tmp.questionText;
        // userChoice.text = tmp.userAnswer;
        for (var i = 0; i < options.Length; i++) {
            options[i].text = tmp.options[i];
        }
        var statistics = GetStats(qnum);
        int sum = 0;
        foreach (var stat in statistics) sum += stat;
        for (var i = 0; i < statistics.Count; i++)
        {
            float percentage = (float)statistics[i] / sum;
            percent[i].text = (percentage*100).ToString("0.0")+" %";
            var width = percentage * maxWidth + 1;
            var img = bars[i].GetComponent<Image>();
            img.color = Color.red;
            var rt = bars[i].GetComponent<RectTransform>();
            rt.transform.Translate(-(rt.sizeDelta.x / 2.0f - 5),0,0);
            rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
            rt.transform.Translate(width / 2.0f - 5,0,0);
            arrows[i].gameObject.SetActive(false);
            if (char.ConvertToUtf32(tmp.answer, 0) - char.ConvertToUtf32("A", 0) == i) {
                img.color = Color.green;
            }
            if (char.ConvertToUtf32(tmp.userAnswer, 0) - char.ConvertToUtf32("A", 0) == i) {
                arrows[i].gameObject.SetActive(true);
            }
        }
    }

    List<int> GetStats(int QN)
    {
        // TODO
        return new List<int>{0,0,0,1};
        // return new List<int>{Random.Range(0,10),Random.Range(0,10),Random.Range(0,10),Random.Range(0,10)};
    }
}
