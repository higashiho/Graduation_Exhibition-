using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneMove;
using Cysharp.Threading.Tasks; 
using DG.Tweening;

namespace UI
{
    /// <summary>
    /// タイトルシーン挙動管理用スクリプト
    /// </summary>
    public class TitleSceneUIController : BaseUI
    {
        /// <summary>
        /// ボタンを押したときの処理
        /// </summary>
        public void Fadeout()
        {
            if(BaseSceneMove.SceneInstance.FadeoutTween == null)
                // シーンコントローラーのフェイドアウト関数呼び出し
                SceneMoveController.SceneInstance.TmpSceneMove.Fadeout();

        }

        void Start()
        {
            StartPlayPos = MoveImage.transform.localPosition;
            titleMove = new TitleMove(this);
            titleMove.StartMove();
        }

        void OnDestroy()
        {
            DOTween.KillAll();
            cts?.Cancel();
        }
    }
}
