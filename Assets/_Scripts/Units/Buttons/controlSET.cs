using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddValueSet : Singleton<AddValueSet>
{
    public SelectableUI selectedObject;
    public void addValue() {
        // Assuming the TextMeshProUGUI component is in the selected object or one of its children
        TextMeshProUGUI textMeshPro = selectedObject.GetComponentInChildren<TextMeshProUGUI>();

        if (textMeshPro != null && selectedObject != null) {
            string val = textMeshPro.text;

            // Try to parse the text as a double
            if (double.TryParse(val, out double num)) {
                num += 0.25;
                
                val = num.ToString("F2"); // Format the number with 2 decimal places
                if (num > 0) {
                    textMeshPro.text = "+" + val;
                } else {
                    textMeshPro.text = val;
                }
                
            } else {
                Debug.LogWarning("The text is not a valid number.");
            }
        } else {
            Debug.LogError("TextMeshProUGUI or selectedObject component not found on the selected object.");
        }
    }
}
