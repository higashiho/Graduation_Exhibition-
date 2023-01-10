using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 

public class TrumpUI
{
    public static TrumpUI Trumps{get;private set;} = new TrumpUI();


    private bool playFlag = true;
    public  bool PlayFlag{get {return playFlag;}set {playFlag = value;}}

    // UIの挙動
    public void Move(BaseUI tmpUI)
    {
        // プレイヤーがトランプを打ったら再生
        if(!InGameController.Player.ShotFlag)
        {
            sliderMove(tmpUI);
        }
    }

    // UI挙動
    private void sliderMove(BaseUI tmpUI)
    {
        tmpUI.TrumpSlider.value -= Time.deltaTime;
    }
}
