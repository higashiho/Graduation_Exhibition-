using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ExplanationMove
    {
        private float alpha = 1;
        private Color textColor = new Color(0, 0, 0, 0);
        // 挙動
        public void Move(BaseUI tmpUI)
        {
            var tmpColorBool = false;
            // Playerが指定のposにいる場合徐々に表示
            if(InGameSceneController.Player.transform.position.y >= Const.EXPLANATION_DISPLAY_POS[0] &&
                InGameSceneController.Player.transform.position.y <= Const.EXPLANATION_DISPLAY_POS[1] &&
                InGameSceneController.Player.transform.position.x >= Const.EXPLANATION_DISPLAY_POS[2] &&
                InGameSceneController.Player.transform.position.x <= Const.EXPLANATION_DISPLAY_POS[3])
            {
                Debug.Log("in");
                // 透明度が最大値ではない場合
                if(alpha <= Const.MAX_ALPHA)
                    alpha += Time.deltaTime;
                tmpColorBool = true;
            }
            // 透明度が最小値ではなく、挙動されていない場合
                if(alpha >= 0 && !tmpColorBool)
                    alpha -= Time.deltaTime;
            textColor.a = alpha;
            // テキストのアルファ値を更新
            for(int i = 0; i < tmpUI.ExpText.Length; i++)
                tmpUI.ExpText[i].color = textColor;
        }
    }
}