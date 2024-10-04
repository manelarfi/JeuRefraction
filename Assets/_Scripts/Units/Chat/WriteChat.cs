using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteChat : MonoBehaviour
{
    public TMP_Text TMPtext;
    
    public void loadChat (string text) {
        TMPtext.text = text;
    }
}
