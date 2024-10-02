using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRefraction", menuName = "ScriptableObjects/Refraction", order = 2)]
public class RefractionSO : ScriptableObject
{
        public float SPD; // Sphère Droite (dioptrie pour l'œil droit)
        public float SPG; // Sphère Gauche (dioptrie pour l'œil gauche)
        public float CPD; // Cylindre pour l'œil droit
        public float CPG; // Cylindre pour l'œil gauche
        public float APD; // Axe pour l'œil droit
        public float APG; // Axe pour l'œil gauche
}
