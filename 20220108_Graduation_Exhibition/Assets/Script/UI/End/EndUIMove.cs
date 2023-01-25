using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SceneMove;
using DG.Tweening;
using Cysharp.Threading.Tasks; 


namespace UI
{
    public class EndUIMove
    {
        private BaseUI tmpUI;
        public EndUIMove(BaseUI tmp)
        {
            tmpUI = tmp;
        }

        /// <summary>
        /// エンドシーンでのテキスト表示関数
        /// </summary>
        public async void Move()
        {
            await UniTask.WaitWhile(() => BaseSceneMove.SceneInstance.FadePanel.color.a != 0);

            // ゲームCLEARステートがたっていたらスコア表示
            if((BaseSceneMove.SceneInstance.SceneState | Const.SCENE_MAIN_GAME_CLEAR) == Const.SCENE_RESULT)
            {

                if(!tmpUI.ScoreText.transform.parent.gameObject.activeSelf)
                    tmpUI.ScoreText.transform.parent.gameObject.SetActive(true);
                tmpUI.ScoreText.text = "" + BaseUI.HaveItem;

                await clearTextMove();
            }
            else 
            {
                if(!tmpUI.GameOverText.gameObject.activeSelf)
                    tmpUI.GameOverText.gameObject.SetActive(true);
                await faileTextMove();
            }


        }

        /// <summary>
        /// 失敗時のテキスト挙動
        /// </summary>
        /// <returns></returns>
        private async UniTask faileTextMove()
        {
            var tmpTweem = tmpUI.GameOverText.transform.DOLocalMove(Const.MOVE_TARGET_POS,Const.MOVE_TIME).SetEase(Ease.OutBounce);

            // Tweenが終了するまで待つ
            await tmpTweem.AsyncWaitForCompletion();

            // １秒で100値が増えるループ
            await characterSpacingMove(tmpUI.GameOverText);

        }

        /// <summary>
        /// クリア時のテキスト挙動
        /// </summary>
        /// <returns></returns>
        private async UniTask clearTextMove()
        {
            // 取得個数テキスト
            var tmpTween = tmpUI.ScoreText.DOFade(Const.MAX_ALPHA,Const.FADE_TIME).SetEase(Ease.InCirc);
            await tmpTween.AsyncWaitForCompletion();

            // テキストの子挙動
            var tmpText = tmpUI.ScoreText.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            tmpText.DOFade(Const.MAX_ALPHA,Const.FADE_TIME).SetEase(Ease.InCirc);
            await characterSpacingMove(tmpText);
        }

        /// <summary>
        /// １秒でcharacterSpacingの値が100増えるループ
        /// </summary>
        /// <returns></returns>
        private async UniTask characterSpacingMove(TextMeshProUGUI tmpTextUI)
        {
             while(true)
            {
                // characterSpacingの値を１増やす
                var tmpWidth = tmpTextUI.characterSpacing;
                tmpWidth++;
                tmpTextUI.characterSpacing = tmpWidth;

                // 0.01秒待つ
                await UniTask.Delay(Const.WAIT_TIME);
                if(tmpWidth >= 0)
                    break;
            }
        }

    }
}