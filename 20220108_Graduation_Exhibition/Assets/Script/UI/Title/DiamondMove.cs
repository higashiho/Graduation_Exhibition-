using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class DiamondMove
    {
        private BaseUI tmpUI;

        public DiamondMove(BaseUI tmp)
        {
            tmpUI = tmp;
        }

        /// <summary>
        /// 全体挙動
        /// </summary>
        public void Move()
        {
            instanceMove();
        }

        /// <summary>
        /// 生成挙動
        /// </summary>
        private void instanceMove()
        {
            if (Input.GetMouseButtonDown(0) && !tmpUI.OnButton)
            {
                //マウスカーソルの位置を取得。
                var mousePosition = Input.mousePosition;
                
                BaseDiamond tmpObj = null;
                foreach(var tmp in tmpUI.Diamonds)
                {
                    if(!tmp.gameObject.activeSelf)
                    {
                        tmpObj = tmp;
                        tmpObj.transform.position = mousePosition;
                    }
                }
                if(tmpObj == null)
                {
                    // 代入生成
                    tmpObj = MonoBehaviour.Instantiate
                    (tmpUI.Diamond, mousePosition,
                    Quaternion.identity,tmpUI.transform);
                    tmpUI.Diamonds.Add(tmpObj);
                }

                // 向きをランダムに変換して描画
                tmpObj.transform.localEulerAngles = new Vector3(0,0,UnityEngine.Random.Range(-Const.MIN_MAX_ANGLE, Const.MIN_MAX_ANGLE));
                if(!tmpObj.gameObject.activeSelf)
                    tmpObj.gameObject.SetActive(true);
            }
        }   
    }
}

