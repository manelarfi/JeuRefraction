using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MTableManager : Singleton<MTableManager> 
{
    
    // Serialized backing fields visible in the Inspector
    [SerializeField] private TMP_Text SDText;  // Sphère Droite
    [SerializeField] private TMP_Text SGText;  // Sphère Gauche
    [SerializeField] private TMP_Text CDText;  // Cylindre Droite
    [SerializeField] private TMP_Text CGText;  // Cylindre Gauche
    [SerializeField] private TMP_Text ADText;  // Axe Droite
    [SerializeField] private TMP_Text AGText;  // Axe Gauche

    // Properties with custom getters and setters for all text fields
    public double SD
    {
        get
        {
            double result;
            return double.TryParse(SDText.text, out result) ? result : 0.0;
        }
        set => SDText.text = value.ToString("0.00");
    }

    public double SG
    {
        get
        {
            double result;
            return double.TryParse(SGText.text, out result) ? result : 0.0;
        }
        set => SGText.text = value.ToString("0.00");
    }

    public double CD
    {
        get
        {
            double result;
            return double.TryParse(CDText.text, out result) ? result : 0.0;
        }
        set => CDText.text = value.ToString("0.00");
    }

    public double CG
    {
        get
        {
            double result;
            return double.TryParse(CGText.text, out result) ? result : 0.0;
        }
        set => CGText.text = value.ToString("0.00");
    }

    public double AD
    {
        get
        {
            double result;
            return double.TryParse(ADText.text, out result) ? result : 0.0;
        }
        set => ADText.text = value.ToString();  // No decimal places for axis
    }

    public double AG
    {
        get
        {
            double result;
            return double.TryParse(AGText.text, out result) ? result : 0.0;
        }
        set => AGText.text = value.ToString();  // No decimal places for axis
    }

    // Method to load AR data from the RefractionSO ScriptableObject
    public void LoadData(RefractionSO AR)
    {
        if (AR)
        {
            SD = AR.SPD;  // Assuming AR has these properties
            SG = AR.SPG;
            CD = AR.CPD;
            CG = AR.CPG;
            AD = AR.APD;
            AG = AR.APG;
        }
    }

    public double FindElement(string TAG)
{
    switch (TAG)
    {
        case "SG":
            return SG;
        case "SD":
            return SD;
        case "CG":
            return CG;
        case "CD":
            return CD;
        case "AG":
            return AG;
        case "AD":
            return AD;
        default:
            Debug.LogError("Invalid tag: " + TAG);
            return 0.0; // Default value in case of no match
    }
}

}
