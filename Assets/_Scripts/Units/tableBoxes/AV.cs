using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AV : MonoBehaviour
{
    public List<TextMeshProUGUI> letters = new List<TextMeshProUGUI>(); // Use List for dynamic resizing
    private System.Random random = new System.Random(); // Random generator instance

    private void Start() {
        SetLettersArray(); // Initialize the letters list
        RandomizeLetters(); // Randomize the letters
    }

    public void SetLettersArray() {
        letters.Clear(); // Clear existing elements if any
        for (int i = 0; i < transform.childCount; i++) {
            TextMeshProUGUI TMProComponent = transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            if (TMProComponent != null) {
                letters.Add(TMProComponent); // Add each TextMeshProUGUI component to the list
            }
        }
    }

    public void RandomizeLetters() {
        foreach (var letter in letters) {
            letter.text = getRandomLetter().ToString(); // Set random letter for each TextMeshProUGUI component
        }
    }

    private char getRandomLetter() {
        char randomLetter = (char)random.Next('A', 'Z' + 1); // Generate random letter
        return randomLetter;
    }
}
