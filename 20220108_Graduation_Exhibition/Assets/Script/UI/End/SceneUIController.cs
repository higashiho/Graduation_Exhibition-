using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI{
    public class SceneUIController : BaseUI
    {
        // インスタンス化
        private EndUIMove uiMove;
        // Start is called before the first frame update
        void Start()
        {
            uiMove = new EndUIMove(this);
            uiMove.Move();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}