using UnityEngine;
using UnityEngine.UI;

public class SelectableUI : MonoBehaviour
{
    private Color originalColor;
    public Color selectedColor = Color.green; // The color to apply when selected

    private bool isSelected = false;

    private void Start() {
        originalColor = GetComponent<Image>().color; // Save the original color of the UI element
    }

    public void Select() {
        isSelected = true;
        GetComponent<Image>().color = selectedColor; // Change the color to the selected color
    }

    public void Deselect() {
        isSelected = false;
        GetComponent<Image>().color = originalColor; // Revert back to the original color
    }

    public bool IsSelected() {
        return isSelected;
    }
}
