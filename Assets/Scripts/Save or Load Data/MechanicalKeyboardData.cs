using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalKeyboardData : MonoBehaviour {

    public KeycapMaterials[] keycapsMaterial;
    public SwitchMaterials[] switchesMaterial;
    public int casesMaterial;
}

[System.Serializable]
public struct KeycapMaterials
{
    public string firstColor;
    public string secondColor;
}

[System.Serializable]
public struct SwitchMaterials
{
    public string switchCase;
    public string stem;
    public string pin;
}