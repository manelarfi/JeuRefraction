using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPatientController", menuName = "ScriptableObjects/PatientController", order = 3)]
public class EyeController : ScriptableObject
{
    [SerializeField] public ValuesAV[] VAcheck = new ValuesAV[11]; // Array to hold 11 AV values
    
    public string GetPatientAnswers(double currentVA, double sphere)
    {
        foreach (var v in VAcheck) {
            Debug.Log(v.VA);
            Debug.Log(currentVA);
            if (Math.Abs(v.VA - currentVA) < 0.0001) { // Use tolerance for double comparison
                foreach (var c in v.chat) {
                    if (sphere >= c.minS && sphere < c.maxS) {
                        Debug.Log(c.patientAnswer);
                        return c.patientAnswer;
                    }
                }
            }
        }

        return null; // Return no message if no match
    }
}

[System.Serializable]
public struct ChatPatient
{
    public double minS;
    public double maxS;
    public string patientAnswer; // Answer for this patient
}

[System.Serializable]
public struct ValuesAV
{
    public double VA; // Visual acuity value
    public List<ChatPatient> chat; // List of ChatPatient for this VA
}
