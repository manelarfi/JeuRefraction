using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch1_5deg : MonoBehaviour
{
    public Image deg5;
    public Image deg1;
    public int Step;

    private void Start() {
        Step = 1;
        UpdateImages();
    }

    public void Deg5to1() {
        Step = 1;
        UpdateImages();
    }

    public void Deg1to5() {
        Step = 5;
        UpdateImages();
    }

    // Helper method to update the images based on Step value
    private void UpdateImages() {
        if (deg1 != null && deg5 != null) {
            deg1.gameObject.SetActive(Step == 1);
            deg5.gameObject.SetActive(Step == 5);
        } else {
            Debug.LogWarning("Images not assigned!");
        }
    }
}
