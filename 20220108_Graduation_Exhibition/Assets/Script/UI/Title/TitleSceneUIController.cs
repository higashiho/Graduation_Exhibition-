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
        /// <summary>
        /// マウスが離れたときのイベント
        /// </summary>
        public void ExitEvent()
        {
             // フラグが立っているときは折る
            if(OnButton)
                OnButton = false;
            
        }

        /// <summary>
        /// マウスが乗った時のイベント
        /// </summary>
        public void EnterEvent()
        {
            // フラグがたっていないときは立てる
            if(!OnButton)
                OnButton = true;
        }
        void Start()
        {
            StartPlayPos = MoveImage.transform.localPosition;
            titleMove = new TitleMove(this);
            diamondMove = new DiamondMove(this);
            titleMove.StartMove();
        }

        void Update()
        {
            diamondMove.Move();
        }

        void OnDestroy()
        {
            DOTween.KillAll();
            cts?.Cancel();
        }
    }
}
