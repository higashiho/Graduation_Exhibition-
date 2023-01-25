using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneMove;
using Cysharp.Threading.Tasks; 
using DG.Tweening;

namespace UI
{
    /// <summary>
    /// ボタン管理用スクリプト
    /// </summary>
    public class ButtonController : BaseButton
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

        async void Start()
        {
            await UniTask.WaitWhile(() => BaseSceneMove.SceneInstance.FadePanel.color.a != 0);
            var tmpWateTime = Const.WAIT_TIME / 2;
            moveButton.transform.DOScale(Vector3.one, tmpWateTime).SetEase(Ease.InCirc);
        }
    }
}
