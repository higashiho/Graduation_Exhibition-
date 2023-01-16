using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using DG.Tweening;

namespace Electric
{
    public class ElectricMove
    {

        /// <summary>
        /// 電力の管理挙動
        /// </summary>
        /// <param name="tmpElectric"></param>  電力クラスの実体
        public void Move(BaseElectric tmpElectric)
        {
            // メインの電気がついているときはプレイヤーたちの電気を消す
            if(tmpElectric.MainLight.enabled)
            {
                // 何度も処理されないように一度のみ動作するようにする
                if(InGameSceneController.Player.MyLight.enabled)
                {
                    InGameSceneController.Player.MyLight.enabled = false;
                    foreach(var tmpEnemy in InGameSceneController.Enemys)
                    {
                        // nullが入ったら抜ける
                        if(!tmpEnemy)
                            break;
                        tmpEnemy.MyLight.enabled = false;
                    }
                    tmpElectric.CameraLight.enabled = false;
                }
            }
            else
            {
                if(!InGameSceneController.Player.MyLight.enabled)
                {
                    InGameSceneController.Player.MyLight.enabled = true;
                    foreach(var tmpEnemy in InGameSceneController.Enemys)
                    {
                         if(!tmpEnemy)
                            break;
                        tmpEnemy.MyLight.enabled = true;
                    }
                    tmpElectric.CameraLight.enabled = true;
                }
            }
            
        }

        /// <summary>
        /// 電力がなくなるか判断用関数
        /// </summary>
        /// <param name="tmpElectric"></param>　電力クラスの実体
        /// <returns></returns>
        public async void ElectricManage(BaseElectric tmpElectric)
        {
            // ワープ回数が最大値と同じになった場合
            if(tmpElectric.ElectricsData.MaxElectric == InGameSceneController.Player.WarpCount && tmpElectric.MainLight.enabled)
            {
                // メインのライトを消してワープ回数を初期化
                tmpElectric.MainLight.enabled = false;
                await electricCharge(tmpElectric);
                InGameSceneController.Player.WarpCount = 0;
            }
        }

        /// <summary>
        /// 電力を貯めるときの処理関数
        /// </summary>
        /// <param name="tmpElectric"></param> 電力クラスの実体
        /// <returns></returns>
        private async UniTask electricCharge(BaseElectric tmpElectric)
        {
            Tween tmpTween = null;

            tweenMove(tmpTween, tmpElectric);

            await UniTask.WaitWhile(() => tmpTween != null);
            await tmpTween.AsyncWaitForCompletion();
        }

        /// <summary>
        /// 電力を戻すTween関数
        /// </summary>
        /// <param name="tmpTween"></param> 全ての処理が終わったフラグを立てるTween格納用
        /// <param name="tmpElectric"></param>　電力クラスの実体
        private async void tweenMove(Tween tmpTween, BaseElectric tmpElectric)
        {
            // UIの子供のスプライトマスクを移動
            var tmpElectricTweem = tmpElectric.ElectricUI[0].transform.GetChild(0).transform.DOMove(
                tmpElectric.ElectricUIPos[0],
                3f
            ).SetEase(Ease.Linear);
            await tmpElectricTweem.AsyncWaitForCompletion();
            tmpElectricTweem = tmpElectric.ElectricUI[1].transform.GetChild(0).transform.DOMove(
                tmpElectric.ElectricUIPos[1],
                3f
            ).SetEase(Ease.Linear);
            await tmpElectricTweem.AsyncWaitForCompletion();
            tmpTween = tmpElectric.ElectricUI[2].transform.GetChild(0).transform.DOMove(
                tmpElectric.ElectricUIPos[2],
                3f
            ).SetEase(Ease.Linear);
        }
    }
}