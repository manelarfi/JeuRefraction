using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPatientController", menuName = "ScriptableObjects/PatientController", order = 3)]
public class EyeController : ScriptableObject
{
    [SerializeField] public ValuesAV[] VAcheck = new ValuesAV[11]; // Array to hold 11 AV values
    [SerializeField] public ValuesAxe[] AxeCheck = new ValuesAxe [2]; //Array of two that contains pos 1 or 2 + answers
    
    public string GetPatientAnswers(double currentVA, double sphere)
    {
        foreach (var v in VAcheck) {
            if (Math.Abs(v.VA - currentVA) < 0.0001) { // Use tolerance for double comparison
                foreach (var c in v.chat) {
                    if (sphere >= c.min && sphere < c.max) {
                        Debug.Log(c.patientAnswer);
                        return c.patientAnswer;
                    }
                }
            }
        }

        return null; // Return no message if no match
    }

    public string SearchAxe(int currentPos, double Axe) {

        switch (currentPos) {
            case 1:
                return SearchAnswer(AxeCheck[0].chat, Axe);
            
            case 2:
                return SearchAnswer(AxeCheck[1].chat, Axe);
        }

        return null;
    }

    public string SearchAnswer (List<ChatPatient> ChatPatient, double value) {
        foreach(var e in ChatPatient) {
            if (value >= e.min && value <= e.max) 
            {
                return e.patientAnswer;
            }
        }
        return null;
    }

}



[System.Serializable]
public struct ChatPatient
{
    public double min;
    public double max;
    public string patientAnswer; // Answer for this patient
}

[System.Serializable]
public struct ValuesAV
{
    public double VA; // Visual acuity value
    public List<ChatPatient> chat; // List of ChatPatient for this VA
}

[System.Serializable]
public struct ValuesAxe
{
    public int position;
    public List<ChatPatient> chat;
}
