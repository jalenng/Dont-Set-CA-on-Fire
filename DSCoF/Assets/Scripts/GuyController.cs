using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuyController : MonoBehaviour
{
    public Animator guy;
    public Image popupFrame;
    public TMP_Text popup;

    private int idle;
    private float timer = 0;
    private bool intro = false;
    private QuestionRunner QR;
    private QuestionManager QM;
    private FireController FC;
    private int state = 0;
    private bool fire = true;
    void Awake()
    {
        idle = guy.GetCurrentAnimatorStateInfo(0).fullPathHash;
        popupFrame.enabled = false;
    }

    void Start()
    {
        QM = GameObject.FindObjectOfType<QuestionManager>().GetComponent<QuestionManager>();
        QR = GameObject.FindObjectOfType<QuestionRunner>().GetComponent<QuestionRunner>();
        FC = GameObject.FindObjectOfType<FireController>().GetComponent<FireController>();
    }

    void Update()
    {
        QR.UpdateQuestion();
        // if (!intro) {
        //     QR.Disable();
        //     Intro();
        //     return;
        // } else if (state == 1) {
        //     QR.Disable();
        //     Correct();
        // } else if (state == 2) {
        //     QR.Disable();
        //     Wrong();
        // } else {
        //     return;
        // }
    }

    void Intro()
    {
        bool escape = timer >= 5;
        if (timer == 0 || escape) {
            if (!escape) {
                WaitEnter();
                popupFrame.enabled = true;
                popup.text = "Welcome!\n Let's Start the game!";
            } else {
                popup.text = "";
                popupFrame.enabled = false;
                WaitExit();
                intro = true;
                QR.Enable();
                QR.UpdateQuestion();
            }
        }
        timer += Time.deltaTime;
    }

    public void HandleAnswer(int index)
    {
        Question Q = QM.questions[index];
        timer = 0;
        if (Q.answer.Trim() == Q.userAnswer.Trim()) {
            state = 1;
        } else {
            state = 2;
            fire = false;
        }
    }

    void Correct()
    {
        bool escape = timer >= 3;
        if (timer == 0 || escape) {
            if (!escape) {
                WaitEnter();
                popupFrame.enabled = true;
                popup.text = "Great Job! You saved CA.";
            } else {
                popup.text = "";
                popupFrame.enabled = false;
                WaitExit();
                QR.Enable();
                state = 0;
                QR.UpdateQuestion();
            }
        }
        timer += Time.deltaTime;
    }

    void Wrong()
    {
        bool escape = timer >= 3;
        if (timer == 0 || escape) {
            if (timer < 3) {
                WaitEnter();
                popupFrame.enabled = true;
                popup.text = "You will get it next time!";
            } else if (timer < 6) {
                popup.text = "New Fire Appeared...!";
            } else if (timer < 9) {
                popup.text = "";
                popupFrame.enabled = false;
                if (!fire) {
                    WaitExit();
                    FC.CreateFire();
                    fire = true;
                }
            } else {
                QR.Enable();
                state = 0;
                QR.UpdateQuestion();
            }
        }
        timer += Time.deltaTime;
    }

    void WaitEnter()
    {
        guy.SetTrigger("enter");
    }

    void WaitExit()
    {
        guy.SetTrigger("exit");
    }
}
