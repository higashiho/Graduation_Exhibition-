using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneMove;

namespace UI
{
    /// <summary>
    /// ボタン管理用スクリプト
    /// </summary>
    public class ButtonController : MonoBehaviour
    {
        public void Fadeout()
        {
            // シーンコントローラーのフェイドアウト関数呼び出し
            SceneMoveController.SceneInstance.TmpSceneMove.Fadeout();

        }
    }
}
