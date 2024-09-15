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
    
    [Header("Additional Information")]
    public string medicalHistory;
    public string currentTreatment;

    private void Start() {
        AccMax = 15 - (age/4);
        AccComfort = AccMax/2;
    }

}
