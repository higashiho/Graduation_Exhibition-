using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Audio;

namespace SceneMove
{
    /// <summary>
    /// シーン挙動関数管理クラス
    /// </summary>
    public class SceneMove
    {
        // 取得用インスタンス化
        private BaseSceneMove tmpScene;
        public SceneMove(BaseSceneMove tmp)
        {
            tmpScene = tmp;
        }
        /// <summary>
        /// シーン挙動関数
        /// </summary>
        public void Move()
        {
            switch(tmpScene.SceneState)
            {
                case Const.SCENE_TITLE:
                    fadein();
                    break;
                case Const.SCENE_MAIN:
                    fadein();
                    break;
                case Const.SCENE_MAIN | Const.SCENE_MAIN_GAME_CLEAR:
                    Debug.Log("SCENE_MAIN_GAME_CLEAR");
                    Fadeout();
                    break;
                case Const.SCENE_MAIN | Const.SCENE_MAIN_GAME_OVER:
                    Debug.Log("SCENE_MAIN_GAME_OVER");
                    Fadeout();
                    break;
                case Const.SCENE_RESULT | Const.SCENE_MAIN_GAME_OVER:
                case Const.SCENE_RESULT | Const.SCENE_MAIN_GAME_CLEAR:
                    if(Input.GetKeyDown(KeyCode.Return) && tmpScene.FadePanel.color.a == 0)
                    {
                        tmpScene.SceneState &= ~ tmpScene.SceneState;
                        tmpScene.SceneState |= Const.SCENE_RESULT;
                        Fadeout();
                    }

                    fadein();
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// フェイドイン関数
        /// </summary>
        private void fadein()
        {
            if(tmpScene.FadeinTween == null)
            {
                tmpScene.FadeinTween = tmpScene.FadePanel.DOFade(0, Const.FADE_TIME).
                SetEase(Ease.Linear).OnComplete(() => 
                {
                    // パネルが表示状態の場合非表示にする
                    if(tmpScene.FadePanel.gameObject.activeSelf)
                        tmpScene.FadePanel.gameObject.SetActive(false);
                });
            }
        }

        /// <summary>
        /// インゲームでのフェイドアウト関数
        /// </summary>
        public void Fadeout()
        {   
            Debug.Log(tmpScene.SceneState);
            tmpScene.FadeoutTween = tmpScene.FadePanel.DOFade(Const.MAX_ALPHA, Const.FADE_TIME).
            SetEase(Ease.Linear).OnStart(() => 
            {
                // パネルが非表示状態の場合表示にする
                if(!tmpScene.FadePanel.gameObject.activeSelf)
                    tmpScene.FadePanel.gameObject.SetActive(true);
            }).OnComplete(compReset);
        }
        
        /// <summary>
        /// フェイドイン用の処理関数
        /// </summary>
        private void compReset()
        {
            if(tmpScene.SceneState == Const.SCENE_TITLE)
            {
                SceneManager.LoadScene("GameScene");
                // フラグを折って次のステートを入れる
                tmpScene.SceneState &= ~tmpScene.SceneState;
                tmpScene.SceneState |= Const.SCENE_MAIN;
                InGameSceneController.audioSource.Play();
            }
            else if(tmpScene.SceneState == Const.SCENE_RESULT)
            {
                SceneManager.LoadScene("TitleScene");
                // フラグを折って次のステートを入れる
                tmpScene.SceneState &= ~tmpScene.SceneState;
                tmpScene.SceneState |= Const.SCENE_TITLE;
            }
            else 
            {
                SceneManager.LoadScene("ResultScene");
                // メインステートフラグのみ折って次のステートを入れる
                tmpScene.SceneState &= ~Const.SCENE_MAIN;
                tmpScene.SceneState |= Const.SCENE_RESULT;
            }
            
            tmpScene.FadeinTween = null;
            tmpScene.FadeoutTween = null;
        }
    }
    

}