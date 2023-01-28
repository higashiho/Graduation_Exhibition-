using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using Player;
using UI;

namespace Trump
{
    public class CreateTrump
    {
        // インスタンス化
        private TrumpMove moveTrump = new TrumpMove();
        // 弾の生成と移動向きを代入する関数
        public void Move(BasePlayer tmpObj, BaseTrump tmpTrump, BaseUI tmpUI)
        {
            if(Input.GetMouseButtonDown(0) && InGameSceneController.Player.ShotFlag)
            {
                InGameSceneController.Player.ShotFlag = false;
                

                // 生成
                BaseTrump clone = InGameSceneController.TrumpObjectPool.Launch(tmpObj.transform.position, InGameSceneController.TrumpObjectPool.BulletList, tmpTrump);

                // クリックした座標の取得（スクリーン座標からワールド座標に変換）
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 向きの生成（Z成分の除去と正規化）
                clone.ShotForward = Vector3.Scale((mouseWorldPos - tmpObj.transform.position), new Vector3(1, 1, 0)).normalized;

                //トランプ投げる音再生
                InGameSceneController.AudioInstance.audioSource.PlayOneShot(InGameSceneController.AudioInstance.ThrowTramp);

                // トランプの挙動
                moveTrump.Move(clone);
            }
        }
    }
}