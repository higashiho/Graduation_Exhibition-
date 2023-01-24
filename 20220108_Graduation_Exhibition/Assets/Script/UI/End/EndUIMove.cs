using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            // ゲームCLEARステートがたっていたらスコア表示
            if((BaseSceneMove.SceneInstance.SceneState | Const.SCENE_MAIN_GAME_CLEAR) == Const.SCENE_RESULT)
            {
                tmpUI.ScoreText.text = "" + BaseUI.HaveItem;
                if(tmpUI.GameOverText.gameObject.activeSelf)
                    tmpUI.GameOverText.gameObject.SetActive(false);
            }
            else 
            {
                if(tmpUI.ScoreText.transform.parent.gameObject.activeSelf)
                    tmpUI.ScoreText.transform.parent.gameObject.SetActive(false);

                await textMove();
            }
            
            
            // クリアかゲームオーバーが立っていたら折る
            BaseSceneMove.SceneInstance.SceneState &= ~(Const.SCENE_MAIN_GAME_CLEAR | Const.SCENE_MAIN_GAME_OVER);
        }

        private async UniTask textMove()
        {
            tmpUI.GameOverText.transform.DOLocalMove(Vector3.zero,Const.MOVE_TIME).SetEase(Ease.InQuad);
            while(true)
            {
                
                await UniTask.Delay(Const.WAIT_TIME);
            }
        }
    }
}