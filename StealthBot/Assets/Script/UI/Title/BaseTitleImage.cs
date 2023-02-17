using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class BaseTitleImage : MonoBehaviour
    {
        protected Tween jumpTween = null;
        // 初期座標
        public Vector3 StartPos{get;protected set;}

        // 最初の挙動が終わったかフラグ
        protected bool endStartMove = false;
        public bool EndStartMove{get{return endStartMove;} set{endStartMove = value;}}
        
        /// <summary>
        /// マウスカーソルを合わせたときのイベント
        /// </summary>
        public void MoveEvent() 
        {
            if(jumpTween == null && EndStartMove)
                jumpTween = this.transform.DOLocalJump(StartPos, Const.IMAGE_JUMP_POWER, Const.IMAGE_JUMP_NUM, Const.IMAGE_JUMP_TIME).
                SetEase(Ease.Linear).OnComplete(() => jumpTween = null);
        }

    }
}

