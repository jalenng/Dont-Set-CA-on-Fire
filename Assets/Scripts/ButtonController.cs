using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public GameObject[] buttons;
    public Sprite[] Original;
    public Sprite[] Hover;
    private Text[] objs;
    // void Start()
    // {
    //     for (var i = 0; i < buttons.Length; i++) {
    //         var button = buttons[i];
    //         var go = button.GetComponentInChildren<TMP_Text>().gameObject;
    //         Debug.Log(go);
    //         AddEvent(go, EventTriggerType.PointerEnter, delegate { OnEnter(go, i); });
    //         AddEvent(go, EventTriggerType.PointerExit, delegate { OnExit(go, i); });
    //     }
    // }

    // protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    // {
    //     EventTrigger trigger = obj.GetComponent<EventTrigger>();
    //     var eventTrigger = new EventTrigger.Entry();
    //     eventTrigger.eventID = type;
    //     eventTrigger.callback.AddListener(action);
    //     trigger.triggers.Add(eventTrigger);
    // }

    // public void OnEnter(GameObject obj, int index)
    // {
    //     Debug.Log(index);
    //     obj.GetComponent<Image>().sprite = Hover[index];
    // }

    // public void OnExit(GameObject obj, int index)
    // {
    //     obj.GetComponent<Image>().sprite = Original[index];
    // }
}
