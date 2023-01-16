using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using Player;
using DG.Tweening;

namespace Warp
{
    public class WarpMove
    {
        /// <summary>
        ///  プレイヤーの挙動Tween
        /// </summary>
        private Tween tmpPlayerTween = null;


        /// <summary>
        /// ワープ挙動関数
        /// </summary>
        /// <param name="tmpWarp"></param> ワープの実体
        public async void Move(BaseWarp tmpWarp)
        {
            // ワープフラグがある時かつステートがワープじゃないとき
            if(tmpWarp.OnWarp && InGameSceneController.Player.PlayerStatus != BasePlayer.PlayerState.WARP)
            {
                // 上ボタンを押された時
                if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    // プレイヤーのステート更新
                    InGameSceneController.Player.PlayerStatus = BasePlayer.PlayerState.WARP;


                    // マスクの元座標取得
                    var tmpMaskPos = InGameSceneController.Player.PlauerMask.transform.position;

                    // プレイヤーの座標をワープ座標に変更して、エネミーの座標を初期化
                    switch(tmpWarp.gameObject.name)
                    {
                        
                        // スタートメカの場合は格納してたワープポジションに移動
                        case "StartWarpMecha":
                            InGameSceneController.Player.PlauerMask.enabled = true;
                            InGameSceneController.Player.PlauerMask.transform.DOMove(
                                InGameSceneController.Player.transform.position,
                                1.5f
                            ).SetEase(Ease.Linear).OnComplete(() => 
                            {
                                playerMove(tmpMaskPos, InGameSceneController.Player.WarpPos);
                            });
                            
                            Debug.Log("out");
                            break;
                        // 通常の場合はスタートメカの位置に移動
                        case "WarpMecha":
                            Debug.Log("in");

                            InGameSceneController.Player.PlauerMask.enabled = true;
                            InGameSceneController.Player.PlauerMask.transform.DOMove(
                                InGameSceneController.Player.transform.position,
                                1.5f
                            ).SetEase(Ease.Linear).OnComplete(() => 
                            {
                                playerMove(tmpMaskPos, InGameSceneController.Player.StartWarpMecha.transform.position);
                            });
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
                    
                    // 移動が完了するまで待つ
                    await tmpPlayerTween.AsyncWaitForCompletion();
                    InGameSceneController.Player.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
                    Debug.Log("座標変更完了");
                }
            }
        }

        /// <summary>
        /// プレイヤーのワープ時挙動
        /// </summary>
        /// <param name="tmpMaskPos"></param> マスクの元座標
        /// <param name="tmpTargetPos"></param> プレイヤーの目標座標
        private void playerMove(Vector3 tmpMaskPos, Vector3 tmpTargetPos)
        {
            InGameSceneController.Player.transform.DOMove(
                tmpTargetPos,
                1.5f
            ).SetEase(Ease.Linear).OnComplete(() =>
            {
                moveComp(tmpMaskPos);
            });
        }

        /// <summary>
        /// ワープ時の初期化挙動
        /// </summary>
        /// <param name="tmpPos"></param> マスクの元座標
        private void moveComp(Vector3 tmpPos)
        {
             tmpPlayerTween = InGameSceneController.Player.PlauerMask.transform.DOMove(
                    tmpPos,
                    1.5f
                ).SetEase(Ease.Linear).OnComplete(() => 
                {
                    InGameSceneController.Player.PlauerMask.enabled = false;
                });
        }
    }
}