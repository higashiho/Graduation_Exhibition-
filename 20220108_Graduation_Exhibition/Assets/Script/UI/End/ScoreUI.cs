using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ScoreUI
    {
        public void PrintScore(BaseUI tmpUI)
        {
            tmpUI.ScoreText.text = "" + BaseUI.HaveItem;
        }
    }
}