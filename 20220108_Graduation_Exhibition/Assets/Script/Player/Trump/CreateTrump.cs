using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 

public class CreateTrump
{
    public static CreateTrump TrumpCreate{get;private set;} = new CreateTrump();

    // 弾の生成と移動向きを代入する関数
    public async void Move(BasePlayer tmpObj, BaseTrump tmpTrump, BaseUI tmpUI)
    {
        if(Input.GetMouseButtonDown(0) && InGameController.Player.ShotFlag)
        {
            InGameController.Player.ShotFlag = false;
            
            // トランプのスライダーを初期化
            tmpUI.TrumpSlider.value = tmpUI.TrumpSlider.maxValue;

            // 生成
            BaseTrump clone = FactoryTrump.objectPool.Launch(tmpObj.transform.position, FactoryTrump.objectPool.BulletList, tmpTrump);

            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            clone.ShotForward = Vector3.Scale((mouseWorldPos - tmpObj.transform.position), new Vector3(1, 1, 0)).normalized;

            // トランプの挙動
            TrumpMove.MoveTrump.Move(clone);

            await shotCoolTime(tmpTrump.TrumpsData);
        }
    }

    // nミリ秒後にshotフラグを初期化
    private async UniTask shotCoolTime(TrumpData trumpData)
    {
        await UniTask.Delay(trumpData.ShotTime * Const.CHANGE_SECOND);

        InGameController.Player.ShotFlag = true;
        TrumpUI.Trumps.PlayFlag = true;
    }
}
