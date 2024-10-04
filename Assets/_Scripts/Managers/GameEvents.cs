using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEvents : Singleton<GameEvents>
{
    public delegate void OnChangeDetected(string answer);
    public event OnChangeDetected onChangeDetected;
    public event Action OnButtonClicked;

    public void ButtonClicked() {
        OnButtonClicked?.Invoke();
    }

    public void ChangeDetected(string answer) {
        onChangeDetected?.Invoke(answer);
    }

}
