using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI{
    public class EndSceneUIController : BaseUI
    {
        // インスタンス化
        private ScoreUI scores = new ScoreUI();
        // Start is called before the first frame update
        void Start()
        {
            scores.PrintScore(this);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}