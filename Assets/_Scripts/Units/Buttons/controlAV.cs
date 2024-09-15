using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class controlAV : MonoBehaviour
{
    public TextMeshProUGUI textVal;
    public AV aV;
    private double num;

    public void IncreaseAV() {
        num = StringToDouble();
        num += 0.1;
        if (num < 1.3) {
            textVal.text = DoubleToString(num);
            aV.SetLettersArray();
            aV.RandomizeLetters();
        }
        
    }

    public void DecreaseAV() {
        num = StringToDouble();
        num -= 0.1;
        if (num >= 0) {
            textVal.text = DoubleToString(num);
            aV.SetLettersArray();
            aV.RandomizeLetters();
        }
    }

    private double StringToDouble() {
        string val = textVal.text;

        // Attempt to parse the string into a double, using invariant culture for consistency
        if (double.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedNum)) {
                return parsedNum;
        } else {
            Debug.LogWarning("The text is not a valid number.");
            return 0.0;  // Default to 0.0 if parsing fails
        }
    }

    private string DoubleToString(double num) {
        // Convert the number back to a string using InvariantCulture for decimal consistency
        return num.ToString("F1", CultureInfo.InvariantCulture);  // "F1" limits to 1 decimal place
    }
}
