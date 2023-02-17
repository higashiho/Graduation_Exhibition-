using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 

namespace UI
{
    public class TrumpUI
    {
        // UIの挙動
        public async void Move(BaseUI tmpUI)
        {
            // プレイヤーがトランプを打ったら再生
            if(!InGameSceneController.Player.ShotFlag && tmpUI.SliderTask == null)
            {
                tmpUI.SliderTask = sliderMove(tmpUI);

                await (UniTask)tmpUI.SliderTask;
            }
        }

        // UI挙動
        private async UniTask sliderMove(BaseUI tmpUI)
        {
            // 最大値の-1（0.01秒で計算しているため0.01かける)
            var tmpValue = (tmpUI.TrumpSlider.maxValue - 1)  * 0.01f;
            
            // トランプのスライダーを初期化
            tmpUI.TrumpSlider.value = tmpUI.TrumpSlider.maxValue;
            
            while(true)
            {
                tmpUI.TrumpSlider.value -= tmpValue;
                await UniTask.Delay(Const.WAIT_TIME);

                if(tmpUI.TrumpSlider.value <= 0)
                    break;
            }

            // 初期化
            tmpUI.SliderTask = null;
            InGameSceneController.Player.ShotFlag = true;
        }
    }
}