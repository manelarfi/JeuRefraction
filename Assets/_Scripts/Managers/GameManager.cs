using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : StaticInstance<GameManager>
{
    public TMP_Text state; // Text to display current state
    public TMP_Text text;

    public PatientSO currentPatient; // Patient ScriptableObject reference
    public GameState State { get; private set; }

    // Kick the game off with the first state
    void Start() => ChangeState(GameState.Sphere);

    // Method to handle changing game state
    public void ChangeState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Sphere:
                handleSphere();
                break;

            case GameState.Cylindre:
                handleCylindre();
                break;

            case GameState.Axe:
                handleAxe();
                break;
        }

        Debug.Log($"New state: {newState}");
    }
    public void NextState()
    {
        int nextStateValue = (int)State + 1;
        
        if (nextStateValue <= 8) {
            SelectionManagerUI.Instance.DeselectAll();
            GameState nextState = (GameState)nextStateValue; // Cast the integer back to the GameState enum
            ChangeState(nextState);
        }
        
    }

    // Method to handle the Sphere state
    private void handleSphere()
    {
        state.text = "sphere : methode brouillard";
    }

    // Placeholder methods for other game states (add your logic here)
    private void handleCylindre()
    {
        state.text = "cylindre : methode";
    }

    private void handleAxe()
    {
        state.text = "axe : methode";
    }
}

// Enum for the various game states
public enum GameState
{
    Sphere = 6,
    Cylindre = 7,
    Axe = 8
}
