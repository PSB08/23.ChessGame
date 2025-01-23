using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIInputReciever))]
public class UIButton : Button
{
    private InputReciever receiver;

    protected override void Awake()
    {
        base.Awake();
        receiver = GetComponent<UIInputReciever>();
        onClick.AddListener(() => receiver.OnInputRecieved());
    }

}
