using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrescTableManager : Singleton<PrescTableManager>
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
}
