using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionManager : MonoBehaviour
{
    private List<Question> allQ;
    public List<Question> questions;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<QuestionManager>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);    // Important!
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        allQ = new List<Question>();
        LoadQuestions();
        questions = new List<Question>();
        ChooseQuestions(10);
    }

    void LoadQuestions()
    {
        var path = Application.dataPath + "/Resources/Data";
        var files = Directory.GetFiles(path);
        foreach (var filepath in files) {
            if (!filepath.EndsWith(".csv")) continue;
            List<List<string>> lines = CSVReader.readFromFilePath(filepath);
            for (int i = 0; i < lines.Count; i++) {
                Question Q = new Question();
                var tmp = lines[i];
                int j = 0;
                Q.questionNumber = int.Parse(tmp[j++]);
                Q.questionText = tmp[j++];
                Q.options = new string[4];
                for (int k = 0; k < 4; k++) {
                    Q.options[k] = tmp[j++];
                }
                Q.answer = tmp[j++];
                allQ.Add(Q);
            }
        }
    }

    void ChooseQuestions(int number)
    {
        HashSet<int> used = new HashSet<int>();
        int i,j;
        for (i = 0; i < number; i++)
        {
            do {
                j = Random.Range(0, allQ.Count);
            } while (used.Contains(j));
            used.Add(j);
            questions.Add(allQ[j]);
        }
    }
}
