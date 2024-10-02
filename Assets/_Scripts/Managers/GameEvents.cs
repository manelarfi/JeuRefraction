using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    // Define a delegate that takes a string parameter (for example, to handle health changes)
    public delegate void OnChangeDetected(string answer);
    
    // Define an event based on that delegate
    public event OnChangeDetected onChangeDetected;

    // Define an event using Action (no parameters needed for a button click)
    public event Action OnButtonClicked;

    // Method to invoke the OnButtonClicked event
    public void ButtonClicked() {
        OnButtonClicked?.Invoke(); // Safely invoke the event
    }

    // Method to invoke the HealthChangedEvent event
    public void ChangeDetected(string answer) {
        onChangeDetected?.Invoke(answer); // Safely invoke the event with the current health string
    }
}
