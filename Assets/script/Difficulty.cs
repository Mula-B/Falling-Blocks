using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty {
    //hoelang het duurt voor het moeilijkste deel van het spel
    static float secondsToDifficulty = 60;
    //method voor classes die weten hoe moeilijker het wordt
    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToDifficulty); 
    }
}
