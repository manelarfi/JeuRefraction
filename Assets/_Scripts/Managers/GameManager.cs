using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : StaticInstance<GameManager>
{
    //creating layers for different components and control layer access depending on the current slide
    LayerMask Sphere ;
    LayerMask Cylindre ;
    LayerMask Axe ;
    public TMP_Text state;
    public GameObject changeDegButtons;
    public GameObject changePosButtons;

    public PatientSO currentPatient; 
    public GameState State { get; private set; }

    
    void Start() {
        ChangeState(GameState.FoggingTechnique);
        Sphere = LayerMask.GetMask("Sphere");
        Cylindre = LayerMask.GetMask("Cylindre");
        Axe = LayerMask.GetMask("Axe");
    }

    // Method to handle changing game state
    public void ChangeState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.FoggingTechnique:
                handleFoggingTech();
                break;

            case GameState.CCR:
                handleCCR();
                break;

            case GameState.AxePower:
                handleAxePower();
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
    private void handleFoggingTech()
    {
        state.text = "sphère au palier par la technique du brouillard";
        SelectionManagerUI.Instance.uiLayerMasks.Clear();
        SelectionManagerUI.Instance.uiLayerMasks.Add(LayerMask.GetMask("Sphere"));
        Debug.Log("Added LayerMask: " + Sphere);
    }

    // Placeholder methods for other game states (add your logic here)
    private void handleCCR()
    {
        state.text = "l’axe méthode d’encadrement au CCR";
        changeDegButtons.SetActive(true);
        changePosButtons.SetActive(true);
        SelectionManagerUI.Instance.uiLayerMasks.Clear();
        SelectionManagerUI.Instance.uiLayerMasks.Add(Axe);
    }

    private void handleAxePower()
    {
        state.text = "cylindre : methode";
        SelectionManagerUI.Instance.uiLayerMasks.Clear();
        SelectionManagerUI.Instance.uiLayerMasks.Add(Cylindre);
    }
}

// Enum for the various game states
public enum GameState
{
    FoggingTechnique = 6,
    CCR = 7,
    AxePower = 8
}

//find another enum yesla7 for buttons and permissions to select
