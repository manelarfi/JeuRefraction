using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch1_2Pos : Singleton<Switch1_2Pos>
{
    public Image pos1;
    public Image pos2;
    public int currentPos;

    private void Start() {
        currentPos = 1;
        UpdateImages();
    }

    public void Pos2to1() {
        currentPos = 1;
        UpdateImages();
    }

    public void Pos1to2() {
        currentPos = 2;
        UpdateImages();
    }

    private void UpdateImages() {
        if (pos1 != null && pos2 != null) {
            pos1.gameObject.SetActive(currentPos == 1);
            pos2.gameObject.SetActive(currentPos == 2);
        } else {
            Debug.LogWarning("pos1 and/or pos2 images are not assigned in the Inspector!");
        }
    }
}
