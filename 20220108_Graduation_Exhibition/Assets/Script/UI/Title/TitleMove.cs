using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using System.Threading;
using SceneMove;
using DG.Tweening;

namespace UI
{
    /// <summary>
    /// タイトルシーン挙動
    /// </summary>
    public class TitleMove
    {
        private BaseUI tmpUI;
        public TitleMove(BaseUI tmp)
        {
            tmpUI = tmp;
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        /// <returns></returns>
        public async void StartMove()
        {
            // フェイドアウトが終わるまで待つ
            await UniTask.WaitWhile(() => BaseSceneMove.SceneInstance.FadePanel.color.a != 0);
            // タイトルの挙動
            foreach(var tmpObj in tmpUI.TitleImage)
            {
                if(tmpObj == null)
                    break;
                var tmpImage = tmpObj.GetComponent<BaseTitleImage>();
                var jumpTween = tmpImage.transform.DOLocalJump(tmpImage.StartPos, Const.IMAGE_JUMP_POWER, Const.IMAGE_JUMP_NUM, Const.IMAGE_JUMP_TIME).
                SetEase(Ease.Linear);
                await jumpTween.AsyncWaitForCompletion();
                tmpImage.EndStartMove = true;
            }
        

            // ボタンサイズを上げる
            var tmpWateTime = Const.WAIT_TIME / 4f;
            tmpUI.MoveButton.transform.DOScale(Vector3.one, tmpWateTime).SetEase(Ease.InCirc);

            jumpMove(tmpUI.cts.Token);
        }

        private async void jumpMove(CancellationToken token)
        {
            // プレイヤーとエネミーの挙動
            var tmpTween = tmpUI.MoveImage.transform.DOLocalJump(
                Const.PLAYER_MOVE_TARGET_POS, Const.PLAYER_JUMP_POWER, Const.PLAYER_JUMP_NUM, Const.PLAYER_MOVE_TIME).
                SetDelay(Const.PLAYER_MOVE_DELAY).
                SetEase(Ease.InQuad).OnStart(() => tmpUI.MoveImage.transform.localScale = Vector3.one);

            await tmpTween.AsyncWaitForCompletion();
            
            if (token.IsCancellationRequested)
            {
                return;
            }
            // 反転挙動
            var tmpScale = new Vector3(-1,1,1);
            tmpUI.MoveImage.transform.localScale = tmpScale;
            tmpTween = tmpUI.MoveImage.transform.DOLocalJump(
                tmpUI.StartPlayPos, Const.PLAYER_JUMP_POWER, Const.PLAYER_JUMP_NUM, Const.PLAYER_MOVE_TIME).
                SetDelay(Const.PLAYER_MOVE_DELAY).
                SetEase(Ease.InQuad).OnComplete(() => {jumpMove(token);});
        }
    }
}
