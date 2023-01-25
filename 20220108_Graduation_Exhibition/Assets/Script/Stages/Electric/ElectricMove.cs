using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using System.Threading;

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
        public async void ElectricManage(BaseElectric tmpElectric, CancellationToken token)
        {
            
            // padding更新
            paddingUpdate(tmpElectric);
            
            // ワープ回数が最大値と同じになった場合
            if(tmpElectric.ElectricsData.MaxElectric == InGameSceneController.Player.WarpCount && tmpElectric.MainLight.enabled)
            {
                // メインのライトを消してワープ回数を初期化
                tmpElectric.MainLight.enabled = false;
                await electricCharge(tmpElectric, token);
                
                // キャンセルが要求されている場合
                if ( token.IsCancellationRequested )
                {
                    Debug.Log ( "Canceled." );
                    return;
                }
                // 初期化
                InGameSceneController.Player.WarpCount = 0;
                tmpElectric.MainLight.enabled = true;
            }

        }

        /// <summary>
        /// paddingを更新する変数
        /// </summary>
        /// <param name="tmpElectric"></param>
        private void paddingUpdate(BaseElectric tmpElectric)
        {
            if(InGameSceneController.Player.WarpCount != 0 && tmpElectric.MainLight.enabled)
            {
                // マスクのpaddingを格納してTopの値を最大値にする
                var tmpPadding = tmpElectric.ElectricUI[tmpElectric.ElectricsData.MaxElectric - InGameSceneController.Player.WarpCount].padding;
                if(tmpPadding.w != Const.PADDING_TOP_MAX)
                {
                    tmpPadding.w = Const.PADDING_TOP_MAX;
                    tmpElectric.ElectricUI[tmpElectric.ElectricsData.MaxElectric - InGameSceneController.Player.WarpCount].padding = tmpPadding; 
                }
            }
        }

        /// <summary>
        /// 電力を貯めるときの処理関数
        /// </summary>
        /// <param name="tmpElectric">電力クラスの実体</param> 
        /// <returns></returns>
        private async UniTask electricCharge(BaseElectric tmpElectric, CancellationToken token)
        {
            var tmpPadding = new Vector4(0, 0, 0, 0);

            // PaddingのTopを変更
            for(int i = 0; i < tmpElectric.ElectricUI.Length; i++)
            {
                tmpPadding = tmpElectric.ElectricUI[i].padding;
                // 0.01秒おきに0.2ずつ減らす
                for(int j = 0; j < Const.CHANGE_ELECTRIC_TIME; j++)
                {
            
                    // キャンセルが要求されている場合
                    if ( token.IsCancellationRequested )
                    {
                        Debug.Log ( "Canceled." );
                        return;
                    }
                    // Topの値を少しずつ減らす
                    tmpPadding.w -= Const.PADDING_UP_NAM;
                    tmpElectric.ElectricUI[i].padding = tmpPadding;
                    await UniTask.Delay(Const.ELECTRIC_WAIT_TIME);
                }
            }
        }
    }
}