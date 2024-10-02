using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionManagerUI : Singleton<SelectionManagerUI>
{
    
    public GraphicRaycaster uiRaycaster;
    public EventSystem eventSystem;
    public RectTransform tableBounds; // Reference to the table bounds

    private SelectableUI currentSelected = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerEventData = new PointerEventData(eventSystem)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            uiRaycaster.Raycast(pointerEventData, results);

        
            foreach (RaycastResult result in results)
            {
                SelectableUI selectableUI = result.gameObject.GetComponent<SelectableUI>();

                if (selectableUI != null)
                {
                    SelectObject(selectableUI);
                    AddValueSet.Instance.selectedObject = selectableUI;
                    DecreaseValueSet.Instance.selectedObject = selectableUI;
                    break;
                }
            }

        }
    }

    private void SelectObject(SelectableUI selectedObject)
    {
        // If the clicked object is already selected, do nothing
        if (selectedObject == currentSelected) return;

        // Deselect the currently selected object
        if (currentSelected != null)
        {
            currentSelected.Deselect();
        }

        // Select the new object
        selectedObject.Select();
        currentSelected = selectedObject;
    }

    // Optional: Deselect all UI elements
    public void DeselectAll()
    {
        if (currentSelected != null)
        {
            currentSelected.Deselect();
            currentSelected = null;
        }
    }

    public SelectableUI GetSelectableUI() {
        return currentSelected;
    }

    
}
