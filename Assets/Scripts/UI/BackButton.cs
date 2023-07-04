using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    public void Press()
    {
        button.Select();
        ExecuteEvents.Execute(button.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
    }
}
