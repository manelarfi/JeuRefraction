using UnityEngine;
using TMPro; // Make sure you have TextMeshPro imported

public class RefractionManager : MonoBehaviour
{
    // Reference to the AR ScriptableObject
    public RefractionSO AR;

    // Reference to TextMeshPro fields in the UI
    public TMP_Text SPDText;  // Text field for SPD (Sphère Droite)
    public TMP_Text SPGText;  // Text field for SPG (Sphère Gauche)
    public TMP_Text CPDText;  // Text field for CPD (Cylindre Droite)
    public TMP_Text CPGText;  // Text field for CPG (Cylindre Gauche)
    public TMP_Text APDText;  // Text field for APD (Axe Droite)
    public TMP_Text APGText;  // Text field for APG (Axe Gauche)

    public void LoadAR()
    {
        // Load data from AR (Autorefractor Refraction) ScriptableObject into the text fields
        SPDText.text = AR.SPD.ToString("0.00");  // Format as 2 decimal places
        SPGText.text = AR.SPG.ToString("0.00");
        CPDText.text = AR.CPD.ToString("0.00");
        CPGText.text = AR.CPG.ToString("0.00");
        APDText.text = AR.APD.ToString();        // No decimals needed for axes
        APGText.text = AR.APG.ToString();
    }
}
