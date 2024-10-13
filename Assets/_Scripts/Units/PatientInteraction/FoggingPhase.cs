using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoggingPhase : MonoBehaviour, ResponseInterface
{
    public void GetPatAnswer(PatientSO currentPatient)
    {
        if (SelectionManagerUI.Instance.GetSelectableUI() != null) {
            GameObject selectedObj = SelectionManagerUI.Instance.GetSelectableUI().gameObject;
            string answer;
            switch (selectedObj.tag) {
                case "SD":
                    EyeController OD = currentPatient.OD;
                    answer = OD.GetPatientAnswers(ControlVA.Instance.GetCurrentVA(), MTableManager.Instance.SD);
                    Debug.Log("cc");
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;

                case "SG":
                    EyeController OG = currentPatient.OG;
                    answer = OG.GetPatientAnswers(ControlVA.Instance.GetCurrentVA(), MTableManager.Instance.SG);
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;
            }
        }
    }
}
