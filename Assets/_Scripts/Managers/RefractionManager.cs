using UnityEngine;
using TMPro;
using Unity.VisualScripting; // Make sure you have TextMeshPro imported

public class RefractionManager : Singleton<GameManager>
{
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

    GameEvents.Instance.OnButtonClicked += checkForAnswer;
}


    public void LoadAR()
    {
        MTableManager.Instance.LoadData(AR);
        ARTableManager.Instance.LoadData(AR);
    }

    public void LoadIntoPresc () {
        switch (GameManager.Instance.State) {
            case GameState.Sphere:
                LoadSphere();
                break;

            case GameState.Cylindre:
                LoadCylindre();
                break;

            case GameState.Axe:
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
    

    private void checkForAnswer() {

        if (SelectionManagerUI.Instance.GetSelectableUI() != null) {
            GameObject selectedObj = SelectionManagerUI.Instance.GetSelectableUI().gameObject;
            string answer;
            switch (selectedObj.name) {
                case "SPD":
                    answer = OD.GetPatientAnswers(ControlVA.Instance.GetCurrentVA(), MTableManager.Instance.SD);
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;

                case "SPG":
                    answer = OD.GetPatientAnswers(ControlVA.Instance.GetCurrentVA(), MTableManager.Instance.SG);
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;

                // Add cases for other fields (CPD, CPG, etc.) if necessary
            }
        }
    }
}
