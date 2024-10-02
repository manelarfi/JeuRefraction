using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : StaticInstance<GameManager>
{
    public TMP_Text state; // Text to display current state
    public GameObject SPD; // Sphere Plus Diopter UI element
    public GameObject SPG; // Sphere Plus Glasses UI element
    public GameObject CPD; // Cylinder Plus Diopter UI element
    public GameObject CPG; // Cylinder Plus Glasses UI element
    public GameObject APD; // Axis Plus Diopter UI element
    public GameObject APG; // Axis Plus Glasses UI element

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

    // Method to handle the Sphere state
    private void handleSphere()
    {
        SPD.GetComponent<SelectableUI>().enabled = true; 
        SPG.GetComponent<SelectableUI>().enabled = true; 
        state.text = "sphere : methode brouillard";
    }

    // Placeholder methods for other game states (add your logic here)
    private void handleCylindre()
    {
        CPD.GetComponent<SelectableUI>().enabled = true;
        CPG.GetComponent<SelectableUI>().enabled = true;
        state.text = "cylindre : methode";
        SPD.GetComponent<SelectableUI>().enabled = false; 
        SPG.GetComponent<SelectableUI>().enabled = false; 
    }

    private void handleAxe()
    {
        APD.GetComponent<SelectableUI>().enabled = true;
        APG.GetComponent<SelectableUI>().enabled = true;
        state.text = "axe : methode";
        CPD.GetComponent<SelectableUI>().enabled = false; 
        CPG.GetComponent<SelectableUI>().enabled = false; 
    }
}

// Enum for the various game states
public enum GameState
{
    Sphere = 0,
    Cylindre = 1,
    Axe = 2
}
