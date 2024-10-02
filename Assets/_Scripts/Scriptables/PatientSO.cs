using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPatient", menuName = "ScriptableObjects/Patient", order = 1)]
public class PatientSO : ScriptableObject
{
    [Header("Personal Information")]
    public string patientName;
    public int age;
    public string gender;

    [Header("Medical Information")]
    public float AccMax; //Accommodative max =15-(age/4)
    public float AccComfort; //Accommodation de confort = acc max/2
    public RefractionSO AR;
    public RefractionSO SR;
    public EyeController OD;
    public EyeController OG;

    
    [Header("Additional Information")]
    public string medicalHistory;
    public string currentTreatment;

    public void SetAccMax() {
        AccMax = 15 - (age/4);
    }

    public void SetAccComfort() {
        AccComfort = AccMax/2;
    }

    public RefractionSO GetAR() {
        return AR;
    }

}
