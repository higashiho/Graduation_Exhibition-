using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SceneMove
{
    /// <summary>
    /// シーン挙動ベースクラス
    /// </summary>
    public class BaseSceneMove : MonoBehaviour
    {
        // シーンステート
        protected uint sceneState = Const.SCENE_TITLE;
        public uint SceneState{get{return sceneState;} set{sceneState = value;}}

        // フェイドイン用のTween
        protected Tween fadeinTween;
        public Tween FadeinTween{get{return fadeinTween;} set{fadeinTween = value;}}
        // フェイドアウト用のTween
        protected Tween fadeoutTween;
        public Tween FadeoutTween{get{return fadeoutTween;} set{fadeoutTween = value;}}
        [SerializeField, Header("フェイド用パネル")]
        protected Image fadePanel;
        public Image FadePanel{get{return fadePanel;}}

        // 自身が1つしか出現しないように調整
        public static BaseSceneMove SceneInstance{get;protected set;}
        // インスタンス化
        protected SceneMove sceneMove;
        public SceneMove TmpSceneMove{get{return sceneMove;}}

        /// <summary>
        /// 初めての場合の初期化処理関数
        /// </summary>
        protected void startSet()
        {
            SceneInstance = this;
            DontDestroyOnLoad(this);
            sceneMove = new SceneMove(this);
        }

    }
}
