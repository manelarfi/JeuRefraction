using UnityEngine;
using TMPro;
using Unity.VisualScripting; // Make sure you have TextMeshPro imported

public class RefractionManager : Singleton<GameManager>
{
    //Reference to different Interfaces
    public FoggingPhase FoggingPhaseIn;
    // Reference to the current patient
    PatientSO currentPatient;
    // Reference to the AR ScriptableObject
    RefractionSO AR;
    EyeController OG;
    EyeController OD;

    public int currentAV;

    private void Start() {
    if (GameManager.Instance == null) {
        Debug.LogError("GameManager instance is null.");
        return;
    }

    currentPatient = GameManager.Instance.currentPatient;

    if (currentPatient == null) {
        Debug.LogError("currentPatient is null.");
        return;
    }

    AR = currentPatient.AR;
    OG = currentPatient.OG;
    OD = currentPatient.OD;

    if (AR == null || OG == null || OD == null) {
        Debug.LogError("One or more patient-related references (AR, OG, OD) are null.");
        return;
    }

    GameEvents.Instance.OnButtonClicked += SubscribeMethod;
}

    private void Update() {
        SubscribeMethod();
    }


    public void LoadAR()
    {
        MTableManager.Instance.LoadData(AR);
        ARTableManager.Instance.LoadData(AR);
    }

    //look into this later (kayen plus que 3 state)
    public void LoadIntoPresc () {
        switch (GameManager.Instance.State) {
            case GameState.FoggingTechnique:
                LoadSphere();
                break;

            case GameState.AxePower:
                LoadCylindre();
                break;

            case GameState.CCR:
                LoadAxe();
                break;
        }
    }

    private void LoadSphere () {
        PrescTableManager.Instance.SD = MTableManager.Instance.SD;
        PrescTableManager.Instance.SG = MTableManager.Instance.SG;
    }

    private void LoadCylindre () {
        PrescTableManager.Instance.CD = MTableManager.Instance.CD;
        PrescTableManager.Instance.CG = MTableManager.Instance.CG;
    }

    private void LoadAxe () {
        PrescTableManager.Instance.AD = MTableManager.Instance.AD;
        PrescTableManager.Instance.AG = MTableManager.Instance.AG;
    }

    public void SubscribeMethod() {
        switch(GameManager.Instance.State) {
            case GameState.FoggingTechnique:
                FoggingPhaseIn.GetPatAnswer(currentPatient);
                break;

        }
    }

        
}
