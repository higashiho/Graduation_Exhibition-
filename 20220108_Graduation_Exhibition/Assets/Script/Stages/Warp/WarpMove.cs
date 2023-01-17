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
            if(tmpWarp.OnWarp && 
            InGameSceneController.Player.PlayerStatus != BasePlayer.PlayerState.WARP && 
            InGameSceneController.Player.WarpCount != tmpWarp.ElectricsData.MaxElectric
            )
            {
                // 上ボタンを押された時
                if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    // プレイヤーのステート更新
                    InGameSceneController.Player.PlayerStatus = BasePlayer.PlayerState.WARP;
                    // ワープ回数増加
                    InGameSceneController.Player.WarpCount++;
                    // 当たり判定を削除
                    var tmpCol = InGameSceneController.Player.GetComponent<BoxCollider2D>();
                    var tmpRb = InGameSceneController.Player.GetComponent<Rigidbody2D>();

                    tmpCol.enabled = false;
                    tmpRb.gravityScale = 0;

                    // マスクの元座標取得
                    var tmpMaskPos = 
                    InGameSceneController.Player.PlauerMask.transform.position - InGameSceneController.Player.transform.position;

                    // プレイヤーの座標をワープ座標に変更して、エネミーの座標を初期化
                    switch(tmpWarp.gameObject.name)
                    {
                        
                        // スタートメカの場合は格納してたワープポジションに移動
                        case "StartWarpMecha":
                            startWarpMove(tmpMaskPos, InGameSceneController.Player.WarpPos);
                            
                            Debug.Log("out");
                            break;
                        // 通常の場合はスタートメカの位置に移動
                        case "WarpMecha":
                            Debug.Log("in");
                            startWarpMove(tmpMaskPos, InGameSceneController.Player.StartWarpMecha.transform.position);
                            break;
                        default:
                            break;
                    }
                    enemysMove();
                    
                    // nullの場合は待つ
                    await UniTask.WaitWhile(() => tmpPlayerTween == null);
                    // 移動が完了するまで待つ
                    await tmpPlayerTween.AsyncWaitForCompletion();
                    tmpCol.enabled = true;
                    tmpRb.gravityScale = Const.START_GRAVITY_SCALE;
                    tmpPlayerTween = null;
                    Debug.Log("座標変更完了");
                }
            }
        }
        
        /// <summary>
        ///  エネミーの座標変換
        /// </summary>
        private void enemysMove()
        {

            foreach(var tmpEnemy in InGameSceneController.Enemys)
            {
                // エネミーが入っていない場合
                if(!tmpEnemy)
                    break;
                tmpEnemy.transform.position = tmpEnemy.StartPos;
            }
        }
        
        /// <summary>
        /// ワープ時最初のマスク移動
        /// </summary>
        /// <param name="tmpMaskPos"></param>マスクの元座標
        /// <param name="tmpTargetPos"></param>プレイヤーの目標座標
        private void startWarpMove(Vector3 tmpMaskPos, Vector3 tmpTargetPos)
        {
            InGameSceneController.Player.PlauerMask.enabled = true;
            InGameSceneController.Player.PlauerMask.transform.DOMove(
                InGameSceneController.Player.transform.position,
                Const.WARP_TIME
            ).SetEase(Ease.Linear).OnComplete(() => 
            {
                playerMove(tmpMaskPos, tmpTargetPos);
            });
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
                Const.WARP_TIME
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
                    InGameSceneController.Player.transform.position + tmpPos,
                    Const.WARP_TIME
                ).SetEase(Ease.Linear).OnComplete(() => 
                {
                    InGameSceneController.Player.PlauerMask.enabled = false;
                    InGameSceneController.Player.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
                });
        }
    }
}