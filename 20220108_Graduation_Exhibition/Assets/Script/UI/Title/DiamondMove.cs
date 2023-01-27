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
                        tmpObj.gameObject.SetActive(true);
                        tmpObj.transform.position = mousePosition;
                    }
                }
                if(tmpObj == null)
                {
                    // 代入生成
                    tmpUI.Diamonds.Add(MonoBehaviour.Instantiate
                    (tmpUI.Diamond, mousePosition,
                    Quaternion.identity,tmpUI.transform));
                }
            }
        }   
    }
}

