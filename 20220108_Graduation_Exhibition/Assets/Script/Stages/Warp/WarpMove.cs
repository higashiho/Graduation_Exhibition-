using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 


namespace Warp
{
    public class WarpMove
    {
        /// <summary>
        /// ワープ挙動関数
        /// </summary>
        /// <param name="tmpWarp"></param> ワープの実体
        public async void Move(BaseWarp tmpWarp)
        {
            // ワープフラグがある時
            if(tmpWarp.OnWarp)
            {
                // 上ボタンを押された時
                if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    // プレイヤーの座標をワープ座標に変更して、エネミーの座標を初期化
                    switch(tmpWarp.gameObject.name)
                    {
                        // スタートメカの場合は格納してたワープポジションに移動
                        case "StartWarpMecha":
                            InGameSceneController.Player.transform.position = InGameSceneController.Player.WarpPos;
                            break;
                        // 通常の場合はスタートメカの位置に移動
                        case "WarpMecha":
                            InGameSceneController.Player.transform.position = InGameSceneController.Player.StartWarpMecha.transform.position;
                            break;
                        default:
                            break;
                    }
                    
                    foreach(var tmpEnemy in InGameSceneController.Enemys)
                    {
                        // エネミーが入っていない場合
                        if(!tmpEnemy)
                            break;
                        tmpEnemy.transform.position = tmpEnemy.StartPos;
                    }

                    // 三秒待つ
                    await UniTask.Delay(3 * Const.CHANGE_SECOND);
                    Debug.Log("座標変更完了");
                }
            }
        }
    }
}