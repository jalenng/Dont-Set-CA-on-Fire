using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyController : MonoBehaviour
{
    public Animator guy;

    private QuestionRunner qr;
    private int idle;

    void Awake()
    {
        idle = guy.GetCurrentAnimatorStateInfo(0).fullPathHash;
    }

    void Update()
    {
        if (guy.GetCurrentAnimatorStateInfo(0).fullPathHash != idle) return;
        WaitEnter();
    }

    void WaitEnter()
    {
        guy.SetTrigger("enter");
        guy.SetTrigger("exit");
    }

    void WaitExit()
    {
        guy.SetTrigger("exit");
    }
}
