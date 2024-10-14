using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCR : MonoBehaviour
{
    public void GetPatAnswer(PatientSO currentPatient)
    {
        if (SelectionManagerUI.Instance.GetSelectableUI() != null) {
            GameObject selectedObj = SelectionManagerUI.Instance.GetSelectableUI().gameObject;
            string answer;
            switch (selectedObj.tag) {
                case "AD":
                    EyeController OD = currentPatient.OD;
                    answer = OD.SearchAxe(Switch1_2Pos.Instance.currentPos, MTableManager.Instance.AD);
                    Debug.Log("cc");
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;

                case "AG":
                    EyeController OG = currentPatient.OG;
                    answer = OG.SearchAxe(Switch1_2Pos.Instance.currentPos, MTableManager.Instance.AG);
                    if (answer != null) {
                        GameEvents.Instance.ChangeDetected(answer);
                    }
                    break;
            }
        }
    }
}
