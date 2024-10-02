using UnityEngine;
using TMPro;
using Unity.VisualScripting; // Make sure you have TextMeshPro imported

public class RefractionManager : StaticInstance<GameManager>
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


    // Reference to TextMeshPro fields in the UI
    public TMP_Text SPDText;  // Text field for SPD (Sphère Droite)
    public TMP_Text SPGText;  // Text field for SPG (Sphère Gauche)
    public TMP_Text CPDText;  // Text field for CPD (Cylindre Droite)
    public TMP_Text CPGText;  // Text field for CPG (Cylindre Gauche)
    public TMP_Text APDText;  // Text field for APD (Axe Droite)
    public TMP_Text APGText;  // Text field for APG (Axe Gauche)
    public void LoadAR()
    {
        if (AR) {
            // Load data from AR (Autorefractor Refraction) ScriptableObject into the text fields
            SPDText.text = AR.SPD.ToString("0.00");  // Format as 2 decimal places
            SPGText.text = AR.SPG.ToString("0.00");
            CPDText.text = AR.CPD.ToString("0.00");
            CPGText.text = AR.CPG.ToString("0.00");
            APDText.text = AR.APD.ToString();  // No decimals needed for axes
            APGText.text = AR.APG.ToString();
        }
    }

    private void checkForAnswer() {

        if (SelectionManagerUI.Instance.GetSelectableUI() != null) {
            GameObject selectedObj = SelectionManagerUI.Instance.GetSelectableUI().gameObject;
            double val;
            string answer;
            switch (selectedObj.name) {
                case "SPD":
                    val = TMPtoValue(SPDText);
                    answer = OD.GetPatientAnswers(ControlVA.Instance.GetCurrentVA(), val);
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;

                case "SPG":
                    val = TMPtoValue(SPGText);
                    answer = OD.GetPatientAnswers(ControlVA.Instance.GetCurrentVA(), val);
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;

                // Add cases for other fields (CPD, CPG, etc.) if necessary
            }
        }
    }

    private double TMPtoValue(TMP_Text textField) {
        string valueString = textField.text;

        if (double.TryParse(valueString, out double value)) {
            return value;
        }

        Debug.LogWarning($"Failed to convert TMP_Text content '{valueString}' to double.");
        return 0.0; // Return 0 if parsing fails
    }
}
