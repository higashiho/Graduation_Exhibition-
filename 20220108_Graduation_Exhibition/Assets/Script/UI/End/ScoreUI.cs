using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI
{
    public static ScoreUI Scores{get;private set;} = new ScoreUI();
    public void PrintScore(BaseUI tmpUI)
    {
        tmpUI.ScoreText.text = "" + BaseUI.HaveItem;
    }
}
