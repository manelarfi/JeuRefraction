using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DecreaseValueSet : Singleton<DecreaseValueSet>
{
    public SelectableUI selectedObject;

    public void DecreaseValue() {
        // First, check if the selectedObject is null
        if (selectedObject == null) {
            Debug.LogError("selectedObject is not assigned.");
            return;
        }

        // Try to get the TextMeshProUGUI component in the selected object or one of its children
        TextMeshProUGUI textMeshPro = selectedObject.GetComponentInChildren<TextMeshProUGUI>();

        if (textMeshPro != null) {
            string val = textMeshPro.text;

            // Try to parse the text as a double
            if (double.TryParse(val, out double num)) {
                num -= 0.25;

                // Format the number with 2 decimal places
                val = num.ToString("F2");

                // Add "+" only if the number is positive (0 is neither positive nor negative)
                if (num > 0) {
                    textMeshPro.text = "+" + val;
                } else {
                    textMeshPro.text = val; // negative sign is automatically included if number is negative
                }

                //GameEvents.Instance.ButtonClicked();

            } else {
                Debug.LogWarning("The text is not a valid number.");
            }
        } else {
            Debug.LogError("TextMeshProUGUI component not found on the selected object.");
        }
    }

    internal int GetCurrentVA()
    {
        throw new NotImplementedException();
    }
}
