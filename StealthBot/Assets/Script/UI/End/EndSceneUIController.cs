using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace UI{
    public class EndSceneUIController : BaseUI
    {
        // インスタンス化
        private EndUIMove uiMove;
        // Start is called before the first frame update
        void Start()
        {
            uiMove = new EndUIMove(this);
            uiMove.Move();
        }

        void OnDestroy()
        {
            DOTween.KillAll();
            BaseUI.HaveItem = default;
        }
    }
}