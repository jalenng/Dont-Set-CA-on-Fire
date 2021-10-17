using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string NextScene;
    public Button gameStart;
    void Start()
    {
        gameStart.onClick.AddListener(ToNext);
    }

    void ToNext()
    {
        SceneManager.LoadScene(NextScene);
    }
}
