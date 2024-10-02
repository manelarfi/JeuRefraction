using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlVA : Singleton<ControlVA> 
{
    // Thresholds for visual acuity levels
    private double[] acuityLevels = { 0.1, 0.15, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2 };
    public TextMeshProUGUI textVal;
    private int currentLevelIndex;

    private void Start()
    {
        // Initialize currentLevelIndex to the appropriate level based on visualAcuityLevel
        currentLevelIndex = System.Array.IndexOf(acuityLevels, currentLevelIndex);
        if (currentLevelIndex == -1)
        {
            currentLevelIndex = 10; // Default to 20/20 if not found (adjust if needed)
        }
        UpdateVisualAcuityText();
    }

    public void IncreaseAV()
    {
        if (currentLevelIndex < acuityLevels.Length - 1)
        {
            currentLevelIndex++;
            UpdateVisualAcuityText();
            GameEvents.Instance.ButtonClicked();
        }
    }

    public void DecreaseAV()
    {
        if (currentLevelIndex > 0)
        {
            currentLevelIndex--;
            UpdateVisualAcuityText();
            GameEvents.Instance.ButtonClicked();
        }
    }

    public double GetCurrentVA()
    {
        return acuityLevels[currentLevelIndex];
    }

    private void UpdateVisualAcuityText()
    {
        textVal.text = acuityLevels[currentLevelIndex].ToString();
    }
}
