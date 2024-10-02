using UnityEngine;
using UnityEngine.UI;

public class DynamicHeightAdjuster : MonoBehaviour
{
    public RectTransform contentPanel; // The panel whose height we want to adjust (the Content under Scroll View)
    public float verticalPadding = 10f; // Padding to be added between the bottom of the last child and the bottom of the panel

    private void Update() {
        AdjustHeight();
    }

    // This function will adjust the height of the content panel based on its children's heights
    public void AdjustHeight()
    {
        float totalHeight = 0f;

        // Loop through each child of the content panel
        foreach (RectTransform child in contentPanel)
        {
            if (child.gameObject.activeSelf)
            {
                totalHeight += child.sizeDelta.y; // Add the height of the child
                totalHeight += contentPanel.GetComponent<VerticalLayoutGroup>().spacing; // Add spacing if using a layout group
            }
        }

        // Subtract the extra spacing added after the last child
        totalHeight -= contentPanel.GetComponent<VerticalLayoutGroup>().spacing;

        // Add padding at the bottom
        totalHeight += verticalPadding;

        // Set the height of the content panel
        contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, totalHeight);
    }
}
