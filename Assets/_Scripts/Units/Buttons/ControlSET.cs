using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlSET : Singleton<ControlSET>
{
    public float val; // Increment/Decrement value
    [SerializeField] private float min; // Set min value
    [SerializeField] private float max; // Set max value

    public void Increase()
    {
        SelectableUI selected = SelectionManagerUI.Instance.GetSelectableUI();
        if (selected != null)
        {
            double current = MTableManager.Instance.FindElement(selected.tag);
                current += val;
                current = Mathf.Clamp((float)current, min, max);  // Ensure value is within the allowed range
                SetMTableValue(selected.tag, current);  // Update MTableManager with the new value
            
        }
        else
        {
            Debug.Log("No selection was made");
        }
    }

    public void Decrease()
    {
        SelectableUI selected = SelectionManagerUI.Instance.GetSelectableUI();
        if (selected != null)
        {
            double current = MTableManager.Instance.FindElement(selected.tag);
                current -= val;
                current = Mathf.Clamp((float)current, min, max);  // Ensure value is within the allowed range
                SetMTableValue(selected.tag, current);  // Update MTableManager with the new value
            
        }
        else
        {
            Debug.Log("No selection was made");
        }
    }

    // Method to set the updated value back into MTableManager
    private void SetMTableValue(string tag, double value)
    {
        switch (tag)
        {
            case "SG":
                MTableManager.Instance.SG = value;
                break;
            case "SD":
                MTableManager.Instance.SD = value;
                break;
            case "CG":
                MTableManager.Instance.CG = value;
                break;
            case "CD":
                MTableManager.Instance.CD = value;
                break;
            case "AG":
                MTableManager.Instance.AG = value;
                break;
            case "AD":
                MTableManager.Instance.AD = value;
                break;
            default:
                Debug.LogError("Invalid tag: " + tag);
                break;
        }
    }
}
