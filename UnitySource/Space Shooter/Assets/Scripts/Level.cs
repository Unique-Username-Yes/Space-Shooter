using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int xpRequirement;
    public Wave wave;

    // Store rewards here
    public Reward reward;

    [HideInInspector]
    public bool isUnlocked = false;

    public bool isBossFight = false;
}
